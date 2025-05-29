using Microsoft.AspNetCore.Mvc;
using Portfolio.Models;
using System.Collections.Generic;

namespace Portfolio.Controllers
{
    public class TrabajoController:Controller
    {
        
        private static List<Trabajo> trabajo = new List<Trabajo>();
        
        [HttpGet]
        public IActionResult SubirTrabajo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubirTrabajo(string Titulo, string Descripcion, DateTime Fecha, IFormFile Imagen)
        {
            if (Imagen != null && Imagen.Length > 0)
            {
                var nombreArchivo = Guid.NewGuid().ToString() + Path.GetExtension(Imagen.FileName);
                var rutaGuardar = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagenes", nombreArchivo);

                using (var stream = new FileStream(rutaGuardar, FileMode.Create))
                {
                    Imagen.CopyTo(stream);
                }

                var nuevoTrabajo = new Trabajo
                {
                    Id = trabajo.Count + 1,
                    Titulo = Titulo,
                    Descripcion = Descripcion,
                    Fecha = Fecha,
                    ImagenUrl = "/imagenes/" + nombreArchivo
                };
                trabajo.Add(nuevoTrabajo);

                return RedirectToAction("Galeria");
            }
        
            ViewBag.Mensaje = "La imagen no es valida";
            return View();
        }
        public IActionResult Galeria()
        {
            return View(trabajo);
        }
    }
}
