using Microsoft.EntityFrameworkCore.Migrations;

namespace CoachAthlete.Migrations
{
    public partial class renametestheader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestHeaderID",
                table: "TestHeaders",
                newName: "TestHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TestHeaderId",
                table: "TestHeaders",
                newName: "TestHeaderID");
        }
    }
}
