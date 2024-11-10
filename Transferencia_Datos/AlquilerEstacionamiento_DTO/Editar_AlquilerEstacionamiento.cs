using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Transferencia_Datos.AlquilerEstacionamiento_DTO
{
    public class Editar_AlquilerEstacionamiento
    {
        // ATRIBUTOS:
        [Required]
        public int IdAlquiler { get; set; }


        [Required(ErrorMessage = "Ingrese Una Fecha")]
        public DateTime Fecha { get; set; }


        [Required(ErrorMessage = "Debe Ingresar La Placa del Carro")]
        public string Placa { get; set; }


        public int? Horas { get; set; }


        public decimal? Total { get; set; }



        // Referencia Tabla TiposEstacionamientos:  * RELACION *
        [Required]
        public int IdTipoEstacionamientoEnAlquiler { get; set; }
    }
}
