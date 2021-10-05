using Microsoft.EntityFrameworkCore.Migrations;

namespace Testr.Infrastructure.migrations
{
    public partial class CycleTableUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_cycles",
                table: "cycles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "cycles");

            migrationBuilder.RenameTable(
                name: "cycles",
                newName: "Cycles");

            migrationBuilder.RenameColumn(
                name: "DateRegistered",
                table: "Cycles",
                newName: "DateCreated");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Cycles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cycles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CycleName",
                table: "Cycles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cycles",
                table: "Cycles",
                column: "CycleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cycles",
                table: "Cycles");

            migrationBuilder.RenameTable(
                name: "Cycles",
                newName: "cycles");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "cycles",
                newName: "DateRegistered");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "cycles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "cycles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CycleName",
                table: "cycles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "cycles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_cycles",
                table: "cycles",
                column: "CycleId");
        }
    }
}
