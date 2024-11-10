using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Api_RESTFul.Models
{
    public class TipoEstacionamiento
    {
        // ATRIBUTOS:
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipo { get; set; }


        [Required]
        public string Nombre { get; set; }


        [Required]
        public decimal Precio { get; set; }

    }
}
