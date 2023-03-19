﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Platzi;

#nullable disable

namespace Platzi.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20230319001700_agregarListasII")]
    partial class agregarListasII
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Platzi.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("CategoriaID");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaID = new Guid("6e61333b-8606-4a72-9aa1-486d1ef315e2"),
                            Descripcion = "Descripcion",
                            Nombre = "Primera categoria"
                        });
                });

            modelBuilder.Entity("Platzi.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Estado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Prioridad")
                        .HasColumnType("int");

                    b.HasKey("TareaID");

                    b.HasIndex("CategoriaID");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaID = new Guid("6e61333b-8606-4a72-9aa1-486d1ef315e3"),
                            CategoriaID = new Guid("6e61333b-8606-4a72-9aa1-486d1ef315e2"),
                            Descripcion = "Primera desc",
                            Estado = true,
                            FechaCreacion = new DateTime(2023, 3, 18, 21, 17, 0, 43, DateTimeKind.Local).AddTicks(2990),
                            Nombre = "Primera Categoria",
                            Prioridad = 2
                        });
                });

            modelBuilder.Entity("Platzi.Models.Tarea", b =>
                {
                    b.HasOne("Platzi.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Platzi.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}