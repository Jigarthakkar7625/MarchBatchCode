using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyFirstCoreWebSite.Migrations
{
    /// <inheritdoc />
    public partial class myFirstMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Employees",
                newName: "MyAddress");

            migrationBuilder.AddColumn<string>(
                name: "Address123",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address123",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "MyAddress",
                table: "Employees",
                newName: "Address");
        }
    }
}
