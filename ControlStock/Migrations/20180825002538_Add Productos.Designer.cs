﻿// <auto-generated />
using ControlStock.DAL;
using ControlStock.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ControlStock.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180825002538_Add Productos")]
    partial class AddProductos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ControlStock.Models.Marca", b =>
                {
                    b.Property<int>("MarcaID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("Marca")
                        .HasMaxLength(100);

                    b.HasKey("MarcaID");

                    b.ToTable("Marcas","Productos");
                });

            modelBuilder.Entity("ControlStock.Models.Producto", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MarcaID");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnName("Producto")
                        .HasMaxLength(200);

                    b.HasKey("ProductoID");

                    b.HasIndex("MarcaID");

                    b.ToTable("Productos","Productos");
                });

            modelBuilder.Entity("ControlStock.Models.Producto", b =>
                {
                    b.HasOne("ControlStock.Models.Marca", "Marca")
                        .WithMany("Productos")
                        .HasForeignKey("MarcaID");
                });
#pragma warning restore 612, 618
        }
    }
}
