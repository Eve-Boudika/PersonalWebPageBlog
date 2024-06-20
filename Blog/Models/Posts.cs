using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public string Contenido { get; set; }
    }
}
