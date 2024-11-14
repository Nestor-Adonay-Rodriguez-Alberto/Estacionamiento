using Microsoft.AspNetCore.Mvc;
using Transferencia_Datos.TipoEstacionamientos_DTO;


namespace UI_MVC.Controllers
{
    public class TipoEstacionamientoController : Controller
    {
        // Para Hacer Solicitudes Al Servidor:
        private readonly HttpClient _HttpClient;

        public TipoEstacionamientoController(IHttpClientFactory httpClientFactory)
        {
            _HttpClient = httpClientFactory.CreateClient("API_RESTful");
        }



        // **************** METODOS QUE MANDARAN OBJETOS *****************
        // *****************************************************************

        // OBTIENE TODOS LOS REGISTROS DE LA DB:
        public async Task<IActionResult> Registrados()
        {
            // Solicitud "GET" al Endpoint:
            HttpResponseMessage JSON_Obtenidos = await _HttpClient.GetAsync("/api/TipoEstacionamiento");

            // OBJETO:
            Registrados_TipoEstacionamientos Lista_Tipos = new Registrados_TipoEstacionamientos();

            // True=200-299
            if (JSON_Obtenidos.IsSuccessStatusCode)
            {
                // Deserializamos el Json:
                Lista_Tipos = await JSON_Obtenidos.Content.ReadFromJsonAsync<Registrados_TipoEstacionamientos>();
            }

            return View(Lista_Tipos);
        }

        // OBTIENE UN REGISTRO CON EL MISMO ID:
        public async Task<IActionResult> Detalle_Tipo(int id)
        {
            // Solicitud "GET" al Endpoint:
            HttpResponseMessage JSON_Obtenido = await _HttpClient.GetAsync("/api/TipoEstacionamiento");

            // OBJETO:
            Obtener_TipoEstacionamiento Objeto_Obtenido = new Obtener_TipoEstacionamiento();

            // Codigo Status:
            if (JSON_Obtenido.IsSuccessStatusCode)
            {
                Objeto_Obtenido = await JSON_Obtenido.Content.ReadFromJsonAsync<Obtener_TipoEstacionamiento>();
            }

            return View(Objeto_Obtenido);
        }





        // *******  METODOS QUE RECIBIRAN OBJETOS Y MODIFICARAN LA DB  *******
        // ********************************************************************

        // NOS MANDA A LA VISTA:
        public ActionResult Registrar_Tipo()
        {
            return View();
        }

        // RECIBE UN OBJETO Y LO GUARDA EN LA DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar_Tipo(Crear_TipoEstacionamiento crear_TipoEstacionamiento)
        {
            // Solicitud "POST" al Endpoint:
            HttpResponseMessage Respuesta = await _HttpClient.PostAsJsonAsync("/api/TipoEstacionamiento", crear_TipoEstacionamiento);

            // Codigo Status:
            if (Respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Registrados", "TipoEstacionamiento");
            }

            return View();
        }



        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MANDA A VISTA
        public async Task<IActionResult> Editar_Tipo(int id)
        {
            // Solicitud "GET" al Endpoint:
            HttpResponseMessage JSON_Obtenido = await _HttpClient.GetAsync("/api/TipoEstacimiento/" + id);

            // OBJETO:
            Obtener_TipoEstacionamiento Objeto_Obtenido = new Obtener_TipoEstacionamiento();

            // Codigo Status:
            if (JSON_Obtenido.IsSuccessStatusCode)
            {
                Objeto_Obtenido = await JSON_Obtenido.Content.ReadFromJsonAsync<Obtener_TipoEstacionamiento>();
            }

            Editar_TipoEstacionamiento Objeto_Editar = new Editar_TipoEstacionamiento
            {
                IdTipo = Objeto_Obtenido.IdTipo,
                Nombre = Objeto_Obtenido.Nombre,
                Precio = Objeto_Obtenido.Precio,
            };

            return View(Objeto_Editar);
        }

        // RECIBE EL OBJETO MODIFICADO Y LO MODIFICA EN DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar_Tipo(Editar_TipoEstacionamiento editar_TipoEstacionamiento)
        {
            // Solicitud "PUT" al Endpoint:
            HttpResponseMessage Respuesta = await _HttpClient.PutAsJsonAsync("/api/TipoEstacionamiento", editar_TipoEstacionamiento);

            // Codigo Status:
            if (Respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Registrados", "TipoEstacionamiento");
            }

            return View();
        }



        // BUSCA UN REGISTRO CON EL MISMO ID EN LA DB Y LO MANDA A VISTA
        public async Task<IActionResult> Eliminar_Tipo(int id)
        {
            // Solicitud "GET" al Endpoint:
            HttpResponseMessage JSON_Obtenido = await _HttpClient.GetAsync("/api/TipoEstacimiento/" + id);

            // OBJETO:
            Obtener_TipoEstacionamiento Objeto_Obtenido = new Obtener_TipoEstacionamiento();

            // Codigo Status:
            if (JSON_Obtenido.IsSuccessStatusCode)
            {
                Objeto_Obtenido = await JSON_Obtenido.Content.ReadFromJsonAsync<Obtener_TipoEstacionamiento>();
            }

            return View(Objeto_Obtenido);
        }

        // RECIBE EL OBJETO MODIFICADO Y LO MODIFICA EN DB:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar_Tipo(Obtener_TipoEstacionamiento obtener_TipoEstacionamiento)
        {
            // Solicitud "PUT" al Endpoint:
            HttpResponseMessage Respuesta = await _HttpClient.DeleteAsync("/api/TipoEstacionamiento/" + obtener_TipoEstacionamiento.IdTipo);

            // Codigo Status:
            if (Respuesta.IsSuccessStatusCode)
            {
                return RedirectToAction("Registrados", "TipoEstacionamiento");
            }

            return View();
        }
    
    }
}
