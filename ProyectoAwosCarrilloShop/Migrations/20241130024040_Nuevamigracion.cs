using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAwosCarrilloShop.Migrations
{
    public partial class Nuevamigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CliID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CliNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CliEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CliPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CliCelular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CliDir = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CliFechReg = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CliID);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    CarritoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CliID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.CarritoID);
                    table.ForeignKey(
                        name: "FK_Carritos_Clientes_CliID",
                        column: x => x.CliID,
                        principalTable: "Clientes",
                        principalColumn: "CliID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesCarrito",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CarritoID = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Subtotal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesCarrito", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DetallesCarrito_Carritos_CarritoID",
                        column: x => x.CarritoID,
                        principalTable: "Carritos",
                        principalColumn: "CarritoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesCarrito_Productos_ID",
                        column: x => x.ID,
                        principalTable: "Productos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_CliID",
                table: "Carritos",
                column: "CliID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCarrito_CarritoID",
                table: "DetallesCarrito",
                column: "CarritoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesCarrito");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
