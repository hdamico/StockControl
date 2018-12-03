using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControlStock.Migrations
{
    public partial class addproveedores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaID",
                schema: "Productos",
                table: "Productos");

            migrationBuilder.EnsureSchema(
                name: "Stock");

            migrationBuilder.AlterColumn<int>(
                name: "MarcaID",
                schema: "Productos",
                table: "Productos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RubroID",
                schema: "Productos",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoProductoID",
                schema: "Productos",
                table: "Productos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    Cliente = table.Column<string>(maxLength: 200, nullable: true),
                    EntidadID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Discriminator = table.Column<string>(nullable: false),
                    TipoEntidad = table.Column<int>(nullable: false),
                    CUIT = table.Column<string>(nullable: true),
                    RazonSocial = table.Column<string>(name: "Razon Social", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.EntidadID);
                });

            migrationBuilder.CreateTable(
                name: "Rubros",
                schema: "Productos",
                columns: table => new
                {
                    RubroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rubro = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubros", x => x.RubroID);
                });

            migrationBuilder.CreateTable(
                name: "TiposProductos",
                schema: "Productos",
                columns: table => new
                {
                    TipoProductoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoProducto = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProductos", x => x.TipoProductoID);
                });

            migrationBuilder.CreateTable(
                name: "TiposComprobantes",
                schema: "Stock",
                columns: table => new
                {
                    TipoComprobanteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Columna = table.Column<int>(nullable: false),
                    TipoComprobante = table.Column<string>(maxLength: 100, nullable: false),
                    Sistema = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposComprobantes", x => x.TipoComprobanteID);
                });

            migrationBuilder.CreateTable(
                name: "TiposDepositos",
                schema: "Stock",
                columns: table => new
                {
                    TipoDepositoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoDeposito = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposDepositos", x => x.TipoDepositoID);
                });

            migrationBuilder.CreateTable(
                name: "Comprobantes",
                schema: "Stock",
                columns: table => new
                {
                    ComprobanteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EntidadID = table.Column<int>(nullable: false),
                    FechaComprobante = table.Column<string>(nullable: true),
                    ComprobanteNumero = table.Column<string>(maxLength: 50, nullable: true),
                    TipoComprobanteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comprobantes", x => x.ComprobanteID);
                    table.ForeignKey(
                        name: "FK_Comprobantes_Entidad_EntidadID",
                        column: x => x.EntidadID,
                        principalTable: "Entidad",
                        principalColumn: "EntidadID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comprobantes_TiposComprobantes_TipoComprobanteID",
                        column: x => x.TipoComprobanteID,
                        principalSchema: "Stock",
                        principalTable: "TiposComprobantes",
                        principalColumn: "TipoComprobanteID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depositos",
                schema: "Stock",
                columns: table => new
                {
                    DepositoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Deposito = table.Column<string>(maxLength: 100, nullable: false),
                    TipoDepositoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depositos", x => x.DepositoID);
                    table.ForeignKey(
                        name: "FK_Depositos_TiposDepositos_TipoDepositoID",
                        column: x => x.TipoDepositoID,
                        principalSchema: "Stock",
                        principalTable: "TiposDepositos",
                        principalColumn: "TipoDepositoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallesComprobantes",
                schema: "Stock",
                columns: table => new
                {
                    DetalleComprbanteID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cantidad = table.Column<int>(nullable: false),
                    ComprobanteID = table.Column<int>(nullable: false),
                    Importe = table.Column<decimal>(nullable: false),
                    ProductoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesComprobantes", x => x.DetalleComprbanteID);
                    table.ForeignKey(
                        name: "FK_DetallesComprobantes_Comprobantes_ComprobanteID",
                        column: x => x.ComprobanteID,
                        principalSchema: "Stock",
                        principalTable: "Comprobantes",
                        principalColumn: "ComprobanteID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesComprobantes_Productos_ProductoID",
                        column: x => x.ProductoID,
                        principalSchema: "Productos",
                        principalTable: "Productos",
                        principalColumn: "ProductoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_RubroID",
                schema: "Productos",
                table: "Productos",
                column: "RubroID");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_TipoProductoID",
                schema: "Productos",
                table: "Productos",
                column: "TipoProductoID");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_EntidadID",
                schema: "Stock",
                table: "Comprobantes",
                column: "EntidadID");

            migrationBuilder.CreateIndex(
                name: "IX_Comprobantes_TipoComprobanteID",
                schema: "Stock",
                table: "Comprobantes",
                column: "TipoComprobanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Depositos_TipoDepositoID",
                schema: "Stock",
                table: "Depositos",
                column: "TipoDepositoID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesComprobantes_ComprobanteID",
                schema: "Stock",
                table: "DetallesComprobantes",
                column: "ComprobanteID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesComprobantes_ProductoID",
                schema: "Stock",
                table: "DetallesComprobantes",
                column: "ProductoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Marcas_MarcaID",
                schema: "Productos",
                table: "Productos",
                column: "MarcaID",
                principalSchema: "Productos",
                principalTable: "Marcas",
                principalColumn: "MarcaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Rubros_RubroID",
                schema: "Productos",
                table: "Productos",
                column: "RubroID",
                principalSchema: "Productos",
                principalTable: "Rubros",
                principalColumn: "RubroID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_TiposProductos_TipoProductoID",
                schema: "Productos",
                table: "Productos",
                column: "TipoProductoID",
                principalSchema: "Productos",
                principalTable: "TiposProductos",
                principalColumn: "TipoProductoID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Marcas_MarcaID",
                schema: "Productos",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Rubros_RubroID",
                schema: "Productos",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_TiposProductos_TipoProductoID",
                schema: "Productos",
                table: "Productos");

            migrationBuilder.DropTable(
                name: "Rubros",
                schema: "Productos");

            migrationBuilder.DropTable(
                name: "TiposProductos",
                schema: "Productos");

            migrationBuilder.DropTable(
                name: "Depositos",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "DetallesComprobantes",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "TiposDepositos",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "Comprobantes",
                schema: "Stock");

            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.DropTable(
                name: "TiposComprobantes",
                schema: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Productos_RubroID",
                schema: "Productos",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_TipoProductoID",
                schema: "Productos",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "RubroID",
                schema: "Productos",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "TipoProductoID",
                schema: "Productos",
                table: "Productos");

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
    }
}
