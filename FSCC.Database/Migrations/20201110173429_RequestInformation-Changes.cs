using Microsoft.EntityFrameworkCore.Migrations;

namespace FSCC.Database.Migrations
{
    public partial class RequestInformationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EndPointUsed",
                table: "RequestInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndPointUsed",
                table: "RequestInformation");
        }
    }
}
