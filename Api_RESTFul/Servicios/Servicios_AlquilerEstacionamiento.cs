using Api_RESTFul.Models;
using Microsoft.EntityFrameworkCore;
using Transferencia_Datos.AlquilerEstacionamiento_DTO;
using Transferencia_Datos.TipoEstacionamientos_DTO;
using static Api_RESTFul.Servicios.Descuentos;


namespace Api_RESTFul.Servicios
{
    public class Servicios_AlquilerEstacionamiento
    {

        // REPRESENTA LA DB:
        private readonly MyDBcontext _MyDBcontext;

        // CONSTRUCTOR:
        public Servicios_AlquilerEstacionamiento(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }





        // **************** METODOS QUE MANDARAN OBJETOS *****************
        // *****************************************************************

        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        public async Task<Registrados_AlquilerEstacionamiento> Obtener_Todos()
        {
            List<AlquilerEstacionamiento> Lista_AlquileresEstacionamientos = await _MyDBcontext.AlquilerEstacionamiento
                .Include(x => x.Objeto_TipoEstacionamiento)
                .ToListAsync();

            // DTO a retornar:
            Registrados_AlquilerEstacionamiento Registros_Encontrados = new Registrados_AlquilerEstacionamiento();

            foreach (AlquilerEstacionamiento Registro in Lista_AlquileresEstacionamientos)
            {
                Registros_Encontrados.Lista_AlquilerEstacionamiento.Add(new Registrados_AlquilerEstacionamiento.AlquilerEstacionamiento
                {
                    IdAlquiler = Registro.IdAlquiler,
                    Fecha = Registro.Fecha,
                    Placa = Registro.Placa,
                    Horas = Registro.Horas,
                    Total = Registro.Total,
                    IdTipoEstacionamientoEnAlquiler = Registro.IdTipoEstacionamientoEnAlquiler,
                    Objeto_TipoEstacionamiento = new Registrados_TipoEstacionamientos.TipoEstacionamiento
                    {
                        IdTipo = Registro.Objeto_TipoEstacionamiento.IdTipo,
                        Nombre = Registro.Objeto_TipoEstacionamiento.Nombre,
                        Precio = Registro.Objeto_TipoEstacionamiento.Precio
                    }

                });
            }

            return Registros_Encontrados;
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        public async Task<Obtener_AlquilerEstacionamiento> Obtener_PorId(int id)
        {
            AlquilerEstacionamiento? Objeto_Obtenido = await _MyDBcontext.AlquilerEstacionamiento
                .Include(x => x.Objeto_TipoEstacionamiento)
                .FirstOrDefaultAsync(x => x.IdAlquiler == id);

            if (Objeto_Obtenido == null)
            {
                return null;
            }

            Obtener_AlquilerEstacionamiento AlquilerEstacionamiento = new Obtener_AlquilerEstacionamiento
            {
                IdAlquiler = Objeto_Obtenido.IdAlquiler,
                Fecha = Objeto_Obtenido.Fecha,
                Placa = Objeto_Obtenido.Placa,
                Horas = Objeto_Obtenido.Horas,
                Total = Objeto_Obtenido.Total,
                IdTipoEstacionamientoEnAlquiler = Objeto_Obtenido.IdTipoEstacionamientoEnAlquiler,
                Objeto_TipoEstacionamiento = new Registrados_TipoEstacionamientos.TipoEstacionamiento
                {
                    IdTipo = Objeto_Obtenido.Objeto_TipoEstacionamiento.IdTipo,
                    Nombre = Objeto_Obtenido.Objeto_TipoEstacionamiento.Nombre,
                    Precio = Objeto_Obtenido.Objeto_TipoEstacionamiento.Precio
                }
            };

            return AlquilerEstacionamiento;
        }




        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  *******
        // ********************************************************************

        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        public async Task<int> Registrar_AlquilerEstacionamiento(Crear_AlquilerEstacionamiento crear_AlquilerEstacionamiento)
        {
            TipoEstacionamiento tipoEstacionamiento = await Tipo_Estacionamiento(crear_AlquilerEstacionamiento.IdTipoEstacionamientoEnAlquiler);

            // Objeto a Mapear:
            AlquilerEstacionamiento alquilerEstacionamiento = new AlquilerEstacionamiento
            {
                Fecha = crear_AlquilerEstacionamiento.Fecha,
                Placa = crear_AlquilerEstacionamiento.Placa,
                Horas = crear_AlquilerEstacionamiento.Horas,
                Total = tipoEstacionamiento.Precio,
                IdTipoEstacionamientoEnAlquiler = crear_AlquilerEstacionamiento.IdTipoEstacionamientoEnAlquiler
            };

            Calcular_Descuentos(alquilerEstacionamiento);

            _MyDBcontext.Add(alquilerEstacionamiento);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MODIFICA
        public async Task<int> Editar_AlquilerEstacionamiento(Editar_AlquilerEstacionamiento editar_AlquilerEstacionamiento)
        {
            AlquilerEstacionamiento? Objeto_Obtenido = await _MyDBcontext.AlquilerEstacionamiento
                .Include(x => x.Objeto_TipoEstacionamiento)
                .FirstOrDefaultAsync(x => x.IdAlquiler == editar_AlquilerEstacionamiento.IdAlquiler);


            // Objeto a Mapear:         
            Objeto_Obtenido.Fecha = editar_AlquilerEstacionamiento.Fecha;
            Objeto_Obtenido.Placa = editar_AlquilerEstacionamiento.Placa;
            Objeto_Obtenido.Horas = editar_AlquilerEstacionamiento.Horas;

            if (Objeto_Obtenido.IdTipoEstacionamientoEnAlquiler != editar_AlquilerEstacionamiento.IdTipoEstacionamientoEnAlquiler)
            {
                TipoEstacionamiento tipoEstacionamiento = await Tipo_Estacionamiento(editar_AlquilerEstacionamiento.IdTipoEstacionamientoEnAlquiler);

                Objeto_Obtenido.Total = tipoEstacionamiento.Precio;
                Objeto_Obtenido.IdTipoEstacionamientoEnAlquiler = editar_AlquilerEstacionamiento.IdTipoEstacionamientoEnAlquiler;
            }

            if (editar_AlquilerEstacionamiento.IdTipoEstacionamientoEnAlquiler != 1)
            {
                Objeto_Obtenido.Horas = null;
            }
            

            Calcular_Descuentos(Objeto_Obtenido);

            _MyDBcontext.Update(Objeto_Obtenido);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO ELIMINA:
        public async Task<int> Eliminar_AlquilerEstacionamiento(int id)
        {
            AlquilerEstacionamiento? Objeto_Obtenido = await _MyDBcontext.AlquilerEstacionamiento.FirstOrDefaultAsync(x => x.IdAlquiler == id);

            if (Objeto_Obtenido == null)
            {
                return 0;
            }

            _MyDBcontext.Remove(Objeto_Obtenido);

            return await _MyDBcontext.SaveChangesAsync();
        }





        // METODOS NECESARIOS PARA ALGUNAS FUNCIONES:
        // ******************************************
        private async Task<TipoEstacionamiento> Tipo_Estacionamiento(int id)
        {
            TipoEstacionamiento? Objeto_Obtenido = await _MyDBcontext.TiposEstacionamientos
                .FirstOrDefaultAsync(x => x.IdTipo == id);

            return Objeto_Obtenido;
        }

        private void Calcular_Descuentos(AlquilerEstacionamiento alquilerEstacionamiento)
        {
            if (alquilerEstacionamiento.IdTipoEstacionamientoEnAlquiler == 1)
            {
                PorHoras(alquilerEstacionamiento);
            }

            if (alquilerEstacionamiento.IdTipoEstacionamientoEnAlquiler == 2)
            {
                Media_Jornada(alquilerEstacionamiento);
            }

            if (alquilerEstacionamiento.IdTipoEstacionamientoEnAlquiler == 3)
            {
                Jornada_Completa(alquilerEstacionamiento);
            }
        }

    }
}
