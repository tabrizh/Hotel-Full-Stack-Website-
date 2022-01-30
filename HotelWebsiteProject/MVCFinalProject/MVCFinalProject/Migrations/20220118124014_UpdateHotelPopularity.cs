using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCFinalProject.Migrations
{
    public partial class UpdateHotelPopularity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Popular",
                table: "Hotels",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Popular",
                table: "Hotels");
        }
    }
}
