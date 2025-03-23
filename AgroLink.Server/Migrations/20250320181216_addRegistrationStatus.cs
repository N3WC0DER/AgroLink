using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroLink.Server.Migrations
{
    /// <inheritdoc />
    public partial class addRegistrationStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "RegistrationRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "RegistrationRequests");
        }
    }
}
