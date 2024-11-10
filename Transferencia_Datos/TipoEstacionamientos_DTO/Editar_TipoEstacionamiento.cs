using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Transferencia_Datos.TipoEstacionamientos_DTO
{
    public class Editar_TipoEstacionamiento
    {
        // ATRIBUTOS:
        [Required]
        public int IdTipo { get; set; }


        [Required(ErrorMessage = "Tipo de estacionamiento")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "Ingrese un Precio")]
        public decimal Precio { get; set; }
    }
}
