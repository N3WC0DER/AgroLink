using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgroLink.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintsAndEnumConversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Birtdate",
                table: "Suppliers",
                newName: "Birthdate");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Trucks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "RegistrationRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "ExportRequests",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddCheckConstraint(
                name: "ValidEmail1",
                table: "Users",
                sql: "Email LIKE '%@%.%'");

            migrationBuilder.AddCheckConstraint(
                name: "ValidPhone1",
                table: "Users",
                sql: "Phone LIKE '+7[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");

            migrationBuilder.AddCheckConstraint(
                name: "ValidBirthdate",
                table: "Suppliers",
                sql: "YEAR(GETDATE()) - YEAR(Birthdate) > 18 OR (YEAR(GETDATE()) - YEAR(Birthdate) = 18 AND (MONTH(GETDATE()) > MONTH(Birthdate) OR (MONTH(GETDATE()) = MONTH(Birthdate) AND DAY(GETDATE()) >= DAY(Birthdate)))) ");

            migrationBuilder.AddCheckConstraint(
                name: "ValidEmail",
                table: "RegistrationRequests",
                sql: "Email LIKE '%@%.%'");

            migrationBuilder.AddCheckConstraint(
                name: "ValidPhone",
                table: "RegistrationRequests",
                sql: "Phone LIKE '+7[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "ValidEmail1",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "ValidPhone1",
                table: "Users");

            migrationBuilder.DropCheckConstraint(
                name: "ValidBirthdate",
                table: "Suppliers");

            migrationBuilder.DropCheckConstraint(
                name: "ValidEmail",
                table: "RegistrationRequests");

            migrationBuilder.DropCheckConstraint(
                name: "ValidPhone",
                table: "RegistrationRequests");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "Suppliers",
                newName: "Birtdate");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Trucks",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "RegistrationRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "ExportRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
