using System;


namespace Transferencia_Datos.TipoEstacionamientos_DTO
{
    public class Registrados_TipoEstacionamientos
    {
        // CLASE:
        public class TipoEstacionamiento
        {
            // ATRIBUTOS:
            public int IdTipo { get; set; }

            public string Nombre { get; set; }

            public decimal Precio { get; set; }
        }


        // ALMACENA TODOS LOS Tipos de Estacionamientos DE LA DB:
        public List<TipoEstacionamiento> Lista_TipoEstacionamientos { get; set; }


        // CONSTRUCTOR:
        public Registrados_TipoEstacionamientos()
        {
            Lista_TipoEstacionamientos = new List<TipoEstacionamiento>();
        }

    }
}
