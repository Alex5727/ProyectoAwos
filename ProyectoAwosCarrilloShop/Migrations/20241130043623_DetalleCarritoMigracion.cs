using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAwosCarrilloShop.Migrations
{
    public partial class DetalleCarritoMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesCarrito",
                table: "DetallesCarrito");

            migrationBuilder.DropIndex(
                name: "IX_DetallesCarrito_CarritoID",
                table: "DetallesCarrito");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesCarrito",
                table: "DetallesCarrito",
                columns: new[] { "CarritoID", "ID" });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCarrito_ID",
                table: "DetallesCarrito",
                column: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DetallesCarrito",
                table: "DetallesCarrito");

            migrationBuilder.DropIndex(
                name: "IX_DetallesCarrito_ID",
                table: "DetallesCarrito");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetallesCarrito",
                table: "DetallesCarrito",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesCarrito_CarritoID",
                table: "DetallesCarrito",
                column: "CarritoID");
        }
    }
}
