using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Api_RESTFul.Models
{
    public class AlquilerEstacionamiento
    {
        // ATRIBUTOS:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdAlquiler { get; set; }


        [Required]
        public DateTime Fecha { get; set; }


        [Required]
        public string Placa { get; set; }


        public int? Horas { get; set; }


        [Required]
        public decimal Total { get; set; }



        // Referencia Tabla TiposEstacionamientos:  * RELACION *
        [Required]
        [ForeignKey("Objeto_TipoEstacionamiento")]
        public int IdTipoEstacionamientoEnAlquiler { get; set; }
        public virtual TipoEstacionamiento? Objeto_TipoEstacionamiento { get; set; }
    }
}
