using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        private static List<Trabajo> trabajos = new List<Trabajo>
        {
            new Trabajo {
                Id = 1,
                Titulo = "Tatuaje León",
                Descripcion = "Tatuaje en blanco y negro",
                Fecha = DateTime.Now,
                ImagenUrl = "/imagenes/tatuajes-1.jpg"
            },
            new Trabajo {
                Id = 2,
                Titulo = "Tatuaje Geométrico",
                Descripcion = "Diseño geométrico complejo",
                Fecha = DateTime.Now,
                ImagenUrl = "/imagenes/tatuajes-2.jpg"
            }

        };
         
        public IActionResult Index()
        {

            return View(trabajos);
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
    }
}
