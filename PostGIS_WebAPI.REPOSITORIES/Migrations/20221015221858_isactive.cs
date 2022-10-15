using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGIS_WebAPI.REPOSITORIES.Migrations
{
    public partial class isactive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isactive",
                schema: "public",
                table: "buildings",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isactive",
                schema: "public",
                table: "buildings");
        }
    }
}
