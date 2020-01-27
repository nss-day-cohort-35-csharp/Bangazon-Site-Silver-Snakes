using Microsoft.EntityFrameworkCore.Migrations;

namespace Bangazon.Migrations
{
    public partial class productlocaldelivery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LocalDelivery",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f60dd2d2-4d0b-40a4-8fbe-77e87aadb150", "AQAAAAEAACcQAAAAEH9hCCpZVp8BmjUXq4E7UWQwFq0ufJ8mwtSexgfKROnPV+/v8uflvtHfRmw51NUJaQ==" });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "LocalDelivery",
                value: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "LocalDelivery",
                value: true);

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "LocalDelivery",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalDelivery",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd9d5f74-3ab0-482a-a95b-691a4de60229", "AQAAAAEAACcQAAAAEED1ACuyft4rh1U/vbCgZCwtR71dQ+dqKY9ru+SuNKnTVCUCzzT6EPcT4zgMI+iWSw==" });
        }
    }
}
