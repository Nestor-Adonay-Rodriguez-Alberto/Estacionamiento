using Api_RESTFul.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transferencia_Datos.TipoEstacionamientos_DTO;


namespace Api_RESTFul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEstacionamientoController : ControllerBase
    {

        // COMUNICACION CON SERVICIO:
        private readonly Servicios_TipoEstacionamiento _Servicios;

        // CONSTRUCTOR:
        public TipoEstacionamientoController(Servicios_TipoEstacionamiento servicios)
        {
            _Servicios = servicios;
        }





        // **************** ENDPOINTS QUE MANDARAN OBJETOS *****************
        // *****************************************************************

        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        [HttpGet]
        public async Task<IActionResult> Obtener_Todos()
        {
            // DTO a Retornar:
            Registrados_TipoEstacionamientos TiposEstacionamientos = await _Servicios.Obtener_Todos();

            return Ok(TiposEstacionamientos);
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener_PorId(int id)
        {
            Obtener_TipoEstacionamiento? Objeto_Obtenido = await _Servicios.Obtener_PorId(id);

            if (Objeto_Obtenido == null)
            {
                return NotFound("Registro No Existente.");
            }

            return Ok(Objeto_Obtenido);
        }





        // *******  ENPOINTS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  *******
        // ********************************************************************

        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        [HttpPost]
        public async Task<IActionResult> Registrar_TipoEstacionamiento([FromBody] Crear_TipoEstacionamiento crear_TipoEstacionamiento)
        {
            int Respuesta = await _Servicios.Registrar_TipoEstacionamiento(crear_TipoEstacionamiento);
            
            if (Respuesta > 0)
            {
                return Ok("Nuevo Tipo De Estacionamiento Guardado Correctamente");
            }
            else
            {
                return NotFound("Error Al Guardar el Nuevo Tipo De Estacionamiento.");
            }
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MODIFICA
        [HttpPut]
        public async Task<IActionResult> Editar_TipoEstacionamiento([FromBody] Editar_TipoEstacionamiento editar_TipoEstacionamiento)
        {
            int Respuesta = await _Servicios.Editar_TipoEstacionamiento(editar_TipoEstacionamiento);
            if (Respuesta > 0)
            {
                return Ok("Tipo de Estacionamiento Editado Correctamente");
            }
            else
            {
                return NotFound("Error El Registro No Existe.");
            }

        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO ELIMINA:
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar_TipoEstacionamiento(int id)
        {
            int Respuesta = await _Servicios.Eliminar_TipoEstacionamiento(id);
            if (Respuesta > 0)
            {
                return Ok("Tipo de Estacionamiento Eliminado Correctamente");
            }
            else
            {
                return NotFound("Error El Registro No Existe.");
            }

        }


    }
}
