using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControlStock.Migrations
{
    public partial class Inicio3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Productos");

            migrationBuilder.RenameTable(
                name: "Marcas",
                newSchema: "Productos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                schema: "Productos",
                table: "Marcas",
                newName: "Marca");

            migrationBuilder.AlterColumn<string>(
                name: "Marca",
                schema: "Productos",
                table: "Marcas",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Marcas",
                schema: "Productos");

            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "Marcas",
                newName: "Nombre");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Marcas",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);
        }
    }
}
