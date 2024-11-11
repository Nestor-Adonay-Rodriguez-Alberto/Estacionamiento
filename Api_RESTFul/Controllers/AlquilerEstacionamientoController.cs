using Api_RESTFul.Servicios;
using Microsoft.AspNetCore.Mvc;
using Transferencia_Datos.AlquilerEstacionamiento_DTO;


namespace Api_RESTFul.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquilerEstacionamientoController : ControllerBase
    {
        // COMUNICACION CON SERVICIO:
        private readonly Servicios_AlquilerEstacionamiento _Servicios;

        // CONSTRUCTOR:
        public AlquilerEstacionamientoController(Servicios_AlquilerEstacionamiento servicios)
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
            Registrados_AlquilerEstacionamiento alquilerEstacionamiento = await _Servicios.Obtener_Todos();

            return Ok(alquilerEstacionamiento);
        }


        // OBTIENE UN REGISTRO CON EL MISMO ID:
        [HttpGet("{id}")]
        public async Task<IActionResult> Obtener_PorId(int id)
        {
            Obtener_AlquilerEstacionamiento? Objeto_Obtenido = await _Servicios.Obtener_PorId(id);

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
        public async Task<IActionResult> Registrar_AlquilerEstacionamiento([FromBody] Crear_AlquilerEstacionamiento crear_AlquilerEstacionamiento)
        {
            int Respuesta = await _Servicios.Registrar_AlquilerEstacionamiento(crear_AlquilerEstacionamiento);

            if (Respuesta > 0)
            {
                return Ok("Nuevo Alquiler del Estacionamiento Guardado Correctamente");
            }
            else
            {
                return NotFound("Error Al Guardar el Nuevo Alquiler.");
            }
        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MODIFICA
        [HttpPut]
        public async Task<IActionResult> Editar_AlquilerEstacionamiento([FromBody] Editar_AlquilerEstacionamiento editar_AlquilerEstacionamiento)
        {
            int Respuesta = await _Servicios.Editar_AlquilerEstacionamiento(editar_AlquilerEstacionamiento);
            if (Respuesta > 0)
            {
                return Ok("Alquiler Editado Correctamente");
            }
            else
            {
                return NotFound("Error El Registro No Existe.");
            }

        }


        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO ELIMINA:
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar_AlquilerEstacionamiento(int id)
        {
            int Respuesta = await _Servicios.Eliminar_AlquilerEstacionamiento(id);
            if (Respuesta > 0)
            {
                return Ok("Alquiler Eliminado Correctamente");
            }
            else
            {
                return NotFound("Error El Registro No Existe.");
            }

        }

    }
}
