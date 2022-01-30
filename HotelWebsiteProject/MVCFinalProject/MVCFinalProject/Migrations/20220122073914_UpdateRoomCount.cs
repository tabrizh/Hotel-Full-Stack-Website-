using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCFinalProject.Migrations
{
    public partial class UpdateRoomCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Count",
                table: "Rooms",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "Rooms");
        }
    }
}
