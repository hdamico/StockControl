using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControlStock.Migrations
{
    public partial class AddProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaID",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                newSchema: "Productos");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                schema: "Productos",
                table: "Productos",
                newName: "Producto");

            migrationBuilder.AlterColumn<string>(
                name: "Producto",
                schema: "Productos",
                table: "Productos",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MarcaID",
                schema: "Productos",
                table: "Productos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_MarcaID",
                schema: "Productos",
                table: "Productos",
                column: "MarcaID",
                principalSchema: "Productos",
                principalTable: "Marcas",
                principalColumn: "MarcaID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaID",
                schema: "Productos",
                table: "Productos");

            migrationBuilder.RenameTable(
                name: "Productos",
                schema: "Productos");

            migrationBuilder.RenameColumn(
                name: "Producto",
                table: "Productos",
                newName: "Nombre");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Productos",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "MarcaID",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_MarcaID",
                table: "Productos",
                column: "MarcaID",
                principalSchema: "Productos",
                principalTable: "Marcas",
                principalColumn: "MarcaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
