using System;
using static Transferencia_Datos.TipoEstacionamientos_DTO.Registrados_TipoEstacionamientos;


namespace Transferencia_Datos.AlquilerEstacionamiento_DTO
{
    public class Registrados_AlquilerEstacionamiento
    {
        // CLASE:
        public class AlquilerEstacionamiento
        {
            // ATRIBUTOS:
            public int IdAlquiler { get; set; }
            public DateTime Fecha { get; set; }
            public string Placa { get; set; }
            public int? Horas { get; set; }
            public decimal? Total { get; set; }

            // Referencia Tabla TiposEstacionamientos:  * RELACION *
            public int IdTipoEstacionamientoEnAlquiler { get; set; }
            public virtual TipoEstacionamiento? Objeto_TipoEstacionamiento { get; set; }
        }


        // ALMACENA TODOS LOS AlquilerEstacionamiento DE LA DB:
        public List<AlquilerEstacionamiento> Lista_AlquilerEstacionamiento { get; set;}


        // CONSTRUCTOR:
        public Registrados_AlquilerEstacionamiento()
        {
            Lista_AlquilerEstacionamiento = new List<AlquilerEstacionamiento>();
        }
    }
}
