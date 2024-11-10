using System;
using System.ComponentModel.DataAnnotations;


namespace Transferencia_Datos.TipoEstacionamientos_DTO
{
    public class Obtener_TipoEstacionamiento
    {
        // ATRIBUTOS:
        public int IdTipo { get; set; }

        public string Nombre { get; set; }

        public decimal Precio { get; set; }
    }
}
