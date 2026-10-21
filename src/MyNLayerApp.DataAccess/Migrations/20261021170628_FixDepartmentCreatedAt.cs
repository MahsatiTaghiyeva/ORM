using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyNLayerApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixDepartmentCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2026, 10, 21, 21, 3, 53, 983, DateTimeKind.Local).AddTicks(8480));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2026, 10, 21, 21, 3, 53, 983, DateTimeKind.Local).AddTicks(8480),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");
        }
    }
}
