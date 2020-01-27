using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class SlickNick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4cc7b5ef-376e-44a3-b0fb-1c150b1efd02", "AQAAAAEAACcQAAAAEC1L6wTsSu67vu1bXgCGeZP4E6YlZkvGoTAdoa9UxptH2Rysl33ho82vJCzsKfgxfg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f60dd2d2-4d0b-40a4-8fbe-77e87aadb150", "AQAAAAEAACcQAAAAEH9hCCpZVp8BmjUXq4E7UWQwFq0ufJ8mwtSexgfKROnPV+/v8uflvtHfRmw51NUJaQ==" });
        }
    }
}
