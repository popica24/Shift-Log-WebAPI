using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShiftLoggerAPI.Migrations.Shift
{
    public partial class ShiftMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    ShiftModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartOfShift = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndOfShift = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.ShiftModelId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}
