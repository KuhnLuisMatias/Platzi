using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Platzi;
using Platzi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("conexion"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) =>
{
    try
    {
        dbContext.Database.EnsureCreated();
        return Results.Ok($"Base de datos en memoria {dbContext.Database.IsInMemory()}");
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error al conectarse a la base de datos: {ex.Message}");
    }
});

#region tareas

app.MapGet("/api/tareas", async ([FromServices] TareasContext dbContext) =>
{
    try
    {
        return Results.Ok(dbContext.Tareas.Include(p=>p.Categoria));
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error al conectarse a la base de datos: {ex.Message}");
    }
});


app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
    try
    {
        tarea.TareaID = Guid.NewGuid();
        tarea.FechaCreacion = DateTime.Now;
        await dbContext.AddAsync(tarea);
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error al conectarse a la base de datos: {ex.Message}");
    }
});

app.MapPut("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea, [FromRoute] Guid id) =>
{
    try
    {
        var tareaActual = await dbContext.Tareas.FindAsync(id);

        if(tareaActual != null)
        {
            tareaActual.Nombre = tarea.Nombre;
            tareaActual.Descripcion = tarea.Descripcion;
            tareaActual.Prioridad = tarea.Prioridad;
            tareaActual.Resumen = tarea.Resumen;
            tareaActual.CategoriaID = tarea.CategoriaID;
        }
        
        await dbContext.SaveChangesAsync();
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.BadRequest($"Error al conectarse a la base de datos: {ex.Message}");
    }
});

app.MapDelete("/api/tareas/{id}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid id) => {
    
    var tarea = dbContext.Tareas.Find(id);

    if (tarea == null)
        return Results.NotFound("No se encontró la tarea.");

    dbContext.Remove<Tarea>(tarea);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});
#endregion

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
