using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Platzi.Models
{
    public class Tarea
    {
        [Key]
        public Guid TareaID { get; set; }
        
        [ForeignKey("CategoriaID")]
        public Guid CategoriaID {get;set;}

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Prioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public virtual Categoria Categoria { get; set; }
        public bool Estado { get; set; }

        [NotMapped]
        public string Resumen { get; set; }
    }

    public enum Prioridad
    {
        Baja = 0,
        Media = 1,
        Alta = 2
    }
}
