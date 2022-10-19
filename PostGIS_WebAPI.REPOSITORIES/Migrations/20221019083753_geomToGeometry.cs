using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostGIS_WebAPI.REPOSITORIES.Migrations
{
    public partial class geomToGeometry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "geom",
                schema: "public",
                table: "buildings",
                newName: "geometry");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "geometry",
                schema: "public",
                table: "buildings",
                newName: "geom");
        }
    }
}
