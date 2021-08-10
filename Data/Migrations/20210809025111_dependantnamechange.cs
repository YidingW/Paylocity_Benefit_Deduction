using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class dependantnamechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Dependants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Dependants",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Dependants");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Dependants");
        }
    }
}
