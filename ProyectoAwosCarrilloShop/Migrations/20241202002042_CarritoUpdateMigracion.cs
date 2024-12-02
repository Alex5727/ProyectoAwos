using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoAwosCarrilloShop.Migrations
{
    public partial class CarritoUpdateMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "estado",
                table: "Carritos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estado",
                table: "Carritos");
        }
    }
}
