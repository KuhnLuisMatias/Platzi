using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Platzi.Migrations
{
    /// <inheritdoc />
    public partial class agregarListasII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaID", "Descripcion", "Nombre" },
                values: new object[] { new Guid("6e61333b-8606-4a72-9aa1-486d1ef315e2"), "Descripcion", "Primera categoria" });

            migrationBuilder.InsertData(
                table: "Tarea",
                columns: new[] { "TareaID", "CategoriaID", "Descripcion", "Estado", "FechaCreacion", "Nombre", "Prioridad" },
                values: new object[] { new Guid("6e61333b-8606-4a72-9aa1-486d1ef315e3"), new Guid("6e61333b-8606-4a72-9aa1-486d1ef315e2"), "Primera desc", true, new DateTime(2023, 3, 18, 21, 17, 0, 43, DateTimeKind.Local).AddTicks(2990), "Primera Categoria", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarea",
                keyColumn: "TareaID",
                keyValue: new Guid("6e61333b-8606-4a72-9aa1-486d1ef315e3"));

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "CategoriaID",
                keyValue: new Guid("6e61333b-8606-4a72-9aa1-486d1ef315e2"));
        }
    }
}
