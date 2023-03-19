using Microsoft.EntityFrameworkCore;
using Platzi.Models;

namespace Platzi
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }


        //Fluent API: establecemos la estructura que debe poseer nuestras tablas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categorias = new List<Categoria>();
            categorias.Add(new Categoria 
            { 
                CategoriaID = Guid.Parse("6e61333b-8606-4a72-9aa1-486d1ef315e2"), 
                Nombre = "Primera categoria", Descripcion = "Descripcion" 
            });

            modelBuilder.Entity<Categoria>(cat =>
            {
                cat.ToTable("Categoria");
                cat.HasKey(p => p.CategoriaID);
                cat.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                cat.Property(p => p.Descripcion);
                cat.HasData(categorias);
            });

            List<Tarea> tareas = new List<Tarea>();
            tareas.Add(new Tarea
            {
                TareaID = Guid.Parse("6e61333b-8606-4a72-9aa1-486d1ef315e3"),
                CategoriaID = Guid.Parse("6e61333b-8606-4a72-9aa1-486d1ef315e2"),
                Prioridad = Prioridad.Alta,
                Estado = true,
                Nombre = "Primera Categoria",
                FechaCreacion = DateTime.Now,
                Descripcion = "Primera desc"
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
                tarea.HasData(tareas);
            });
        }

    }
}
