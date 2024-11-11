using Api_RESTFul.Models;
using Microsoft.EntityFrameworkCore;
using Transferencia_Datos.TipoEstacionamientos_DTO;


namespace Api_RESTFul.Servicios
{
    public class Servicios_TipoEstacionamiento
    {

        // REPRESENTA LA DB:
        private readonly MyDBcontext _MyDBcontext;

        // CONSTRUCTOR:
        public Servicios_TipoEstacionamiento(MyDBcontext myDBcontext)
        {
            _MyDBcontext = myDBcontext;
        }





        // **************** METODOS QUE MANDARAN OBJETOS *****************
        // *****************************************************************

        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        public async Task<Registrados_TipoEstacionamientos> Obtener_Todos()
        {
            List<TipoEstacionamiento> Lista_TiposEstacionamientos = await _MyDBcontext.TiposEstacionamientos
                .ToListAsync();

            // DTO a retornar:
            Registrados_TipoEstacionamientos TiposEstacionamientos_Registrados = new Registrados_TipoEstacionamientos();

            foreach (TipoEstacionamiento tipoEstacionamiento in Lista_TiposEstacionamientos)
            {
                TiposEstacionamientos_Registrados.Lista_TipoEstacionamientos.Add(new Registrados_TipoEstacionamientos.TipoEstacionamiento
                {
                    IdTipo = tipoEstacionamiento.IdTipo,
                    Nombre = tipoEstacionamiento.Nombre,
                    Precio=tipoEstacionamiento.Precio
                });
            }

            return TiposEstacionamientos_Registrados;
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        public async Task<Obtener_TipoEstacionamiento> Obtener_PorId(int id)
        {
            TipoEstacionamiento? Objeto_Obtenido = await _MyDBcontext.TiposEstacionamientos
                .FirstOrDefaultAsync(x => x.IdTipo == id);

            if (Objeto_Obtenido == null)
            {
                return null;
            }

            Obtener_TipoEstacionamiento TipoEstacionamiento = new Obtener_TipoEstacionamiento
            {
                IdTipo = Objeto_Obtenido.IdTipo,
                Nombre = Objeto_Obtenido.Nombre,
                Precio = Objeto_Obtenido.Precio              
            };

            return TipoEstacionamiento;
        }





        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  *******
        // ********************************************************************

        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        public async Task<int> Registrar_TipoEstacionamiento(Crear_TipoEstacionamiento crear_TipoEstacionamiento)
        {
            // Objeto a Mapear:
            TipoEstacionamiento tipoEstacionamiento = new TipoEstacionamiento
            {
                Nombre = crear_TipoEstacionamiento.Nombre,
                Precio = crear_TipoEstacionamiento.Precio              
            };

            _MyDBcontext.Add(tipoEstacionamiento);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MODIFICA
        public async Task<int> Editar_TipoEstacionamiento(Editar_TipoEstacionamiento editar_TipoEstacionamiento)
        {
            TipoEstacionamiento? Objeto_Obtenido = await _MyDBcontext.TiposEstacionamientos
                .FirstOrDefaultAsync(x => x.IdTipo == editar_TipoEstacionamiento.IdTipo);

            if (Objeto_Obtenido == null)
            {
                return 0;
            }

            // Modificamos:
            Objeto_Obtenido.Nombre = editar_TipoEstacionamiento.Nombre;
            Objeto_Obtenido.Precio = editar_TipoEstacionamiento.Precio;

            _MyDBcontext.Update(Objeto_Obtenido);

            return await _MyDBcontext.SaveChangesAsync();
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO ELIMINA:
        public async Task<int> Eliminar_TipoEstacionamiento(int id)
        {
            TipoEstacionamiento? Objeto_Obtenido = await _MyDBcontext.TiposEstacionamientos.FirstOrDefaultAsync(x => x.IdTipo == id);

            if (Objeto_Obtenido == null)
            {
                return 0;
            }

            _MyDBcontext.Remove(Objeto_Obtenido);

            return await _MyDBcontext.SaveChangesAsync();
        }


    }
}
