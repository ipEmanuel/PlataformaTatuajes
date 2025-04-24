using System;

namespace Portfolio.Models
{
    public class Trabajo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public DateTime Fecha { get; set; }
    }
}
