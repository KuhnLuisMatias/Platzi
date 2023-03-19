using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        
        [JsonIgnore]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
