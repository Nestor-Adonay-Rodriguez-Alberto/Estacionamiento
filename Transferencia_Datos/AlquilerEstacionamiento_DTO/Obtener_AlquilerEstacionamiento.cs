using System;
using System.ComponentModel.DataAnnotations;
using static Transferencia_Datos.TipoEstacionamientos_DTO.Registrados_TipoEstacionamientos;


namespace Transferencia_Datos.AlquilerEstacionamiento_DTO
{
    public class Obtener_AlquilerEstacionamiento
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
}
