using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class NickSlick : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "93d28e04-e811-445b-9b0c-f35c415bc2ba", "AQAAAAEAACcQAAAAEAjUR9mPlPzZ7aM0v2tO91lhG/YiRKdbclVVIyUgIWHUac+N7lwS/fhkveYMbUm+Ng==" });
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
