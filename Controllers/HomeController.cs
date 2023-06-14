using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WeeCompanyEjercicio.Models;
using static System.Net.WebRequestMethods;

namespace WeeCompanyEjercicio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
       
        public async Task<ActionResult> Create([Bind("Compania,Contacto,Correo,Telefono")] ModelDatos datos)
        {
            if (ModelState.IsValid) 
            {
            HttpClient client = new HttpClient();
                string url = "https://localhost:44323/api/Datos";
                var data = JsonSerializer.Serialize(datos);
            HttpContent content = new StringContent(data,System.Text.Encoding.UTF8,"application/json");
                var httResponse = await client.PostAsync(url, content);
                if (httResponse.IsSuccessStatusCode)
                {
                    // Redirigir a la vista deseada después de realizar el POST
                    return RedirectToAction("Index", "Lista");
                }

            }

            return View(datos);
        }
    }
}