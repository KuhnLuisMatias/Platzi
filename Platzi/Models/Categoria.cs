using System.ComponentModel.DataAnnotations;

namespace Platzi.Models
{
    public class Categoria
    {
        [Key]
        public Guid CategoriaID { get; set; }
        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
