using Microsoft.EntityFrameworkCore;
using Platzi.Models;

namespace Platzi
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(cat =>
            {
                cat.ToTable("Categoria");
                cat.HasKey(p => p.CategoriaID);
                cat.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                cat.Property(p => p.Descripcion);
            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(p => p.TareaID);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaID);
                tarea.Property(p => p.Nombre).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion);
                tarea.Property(p => p.Prioridad);
                tarea.Property(p => p.FechaCreacion);
            });
        }
    }
}
