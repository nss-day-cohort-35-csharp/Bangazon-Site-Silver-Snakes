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
                values: new object[] { "3a4b2805-462d-4ae3-b3eb-43aa97b5a509", "AQAAAAEAACcQAAAAENXJstm2r1OBE22hFcctiNqz6xQ86OZYp0J1BZ8NXHGIcnQsfeWsGKkhUrsKkbUB5g==" });
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
