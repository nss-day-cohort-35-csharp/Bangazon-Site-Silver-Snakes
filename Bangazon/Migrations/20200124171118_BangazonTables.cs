using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class BangazonTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd9d5f74-3ab0-482a-a95b-691a4de60229", "AQAAAAEAACcQAAAAEED1ACuyft4rh1U/vbCgZCwtR71dQ+dqKY9ru+SuNKnTVCUCzzT6EPcT4zgMI+iWSw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "59a7db38-56f7-4da5-adac-4c191595847c", "AQAAAAEAACcQAAAAEEZ+/em+2vef5go0Zw1dQj9Zl52TYQGq/lm0vRh5t5kjrE2wCFhIWWUk0cc11ZGUBA==" });
        }
    }
}
