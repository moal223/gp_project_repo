using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gp_backend.EF.MySql.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeColumnsPharmacyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Close",
                table: "Pharmacies",
                type: "time(6)",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Start",
                table: "Pharmacies",
                type: "time(6)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c7d19b-93ef-42de-a43c-7a2178dd6d48",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1836fec6-c14a-459f-99ef-439e6fd871c2", "AQAAAAIAAYagAAAAECkeMB9klgX/drQmaeamSPmh3Vj2KarKgavAAJDwxkEyE8DH4Zu0CnG+O+JlE4VN9g==", "f6258c99-6a46-444a-8eed-730fadeac081" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Close",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Pharmacies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c7d19b-93ef-42de-a43c-7a2178dd6d48",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9c75555d-aa22-4e87-96d6-9c6555405ac3", "AQAAAAIAAYagAAAAEHunU2QgfJbVeUbi5r4QPY7hhPGqFAA4xmtoKV4GPvVyeamsf+vIqK1Kfg6AzL/Nyw==", "5495db1d-d669-4512-8fd0-70007e126b37" });
        }
    }
}
