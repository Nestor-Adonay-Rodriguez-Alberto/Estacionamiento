using System;
using System.ComponentModel.DataAnnotations;


namespace Transferencia_Datos.TipoEstacionamientos_DTO
{
    public class Crear_TipoEstacionamiento
    {
        // ATRIBUTOS:
        [Required(ErrorMessage ="Tipo de estacionamiento")]
        public string Nombre { get; set; }


        [Required(ErrorMessage ="Ingrese un Precio")]
        public decimal Precio { get; set; }
    }
}
