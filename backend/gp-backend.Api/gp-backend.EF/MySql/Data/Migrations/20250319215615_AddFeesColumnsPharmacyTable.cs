using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace gp_backend.EF.MySql.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFeesColumnsPharmacyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Fees",
                table: "Pharmacies",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c7d19b-93ef-42de-a43c-7a2178dd6d48",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81754d91-503b-4d5e-bd47-129d13d4063d", "AQAAAAIAAYagAAAAEO3mgwo2mGMrVmTW2V8oDrS8rH3kFp+qxyVYv5PF33tWrp4iLyHC26F7hHogmkBOPQ==", "f99e18a1-72e1-41d8-912a-a9cb8881a6d1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fees",
                table: "Pharmacies");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "71c7d19b-93ef-42de-a43c-7a2178dd6d48",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1836fec6-c14a-459f-99ef-439e6fd871c2", "AQAAAAIAAYagAAAAECkeMB9klgX/drQmaeamSPmh3Vj2KarKgavAAJDwxkEyE8DH4Zu0CnG+O+JlE4VN9g==", "f6258c99-6a46-444a-8eed-730fadeac081" });
        }
    }
}
