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
                values: new object[] { "fd9ad60f-ed23-4530-88fa-b6c48897e68e", "AQAAAAEAACcQAAAAEN76W2zMIftTbUPwlGVMQd4R3LBkDZpfffh0SS4zdamiF+1A9Bj73OWyjqTlgC/7qQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd9d5f74-3ab0-482a-a95b-691a4de60229", "AQAAAAEAACcQAAAAEED1ACuyft4rh1U/vbCgZCwtR71dQ+dqKY9ru+SuNKnTVCUCzzT6EPcT4zgMI+iWSw==" });
        }
    }
}
