using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SellX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migra02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7718008b-13c0-4b7d-8cc2-4b984dd63079"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bec12fbd-e8a1-4330-9602-374ade1cc9b2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d51dbeaa-5add-440c-8d0c-022caa4ab66d"));

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                schema: "dbo",
                table: "Products",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "LastName", "Login", "Name", "Order", "Password", "Role", "TenantId" },
                values: new object[,]
                {
                    { new Guid("470571b0-857b-4383-878c-619596e6420f"), false, "sayala@music.com", "Ayala", "chucaro", "Santiago", 0L, "123", "Administrador", new Guid("863e9564-4b31-409d-805f-88465b949f5a") },
                    { new Guid("4cc637ef-845e-4e5b-8d9b-c9a7e7c2f9da"), false, "steve@apple.com", "Jobs", "steve", "Steve", 0L, "123", "Administrador", new Guid("00000001-0001-0001-0001-000000000001") },
                    { new Guid("6462f0fa-3755-4aa8-bda6-4a333eaafeed"), false, "jcafrune@music.com", "Cafrune", "turco", "Jorge", 0L, "123", "Administrador", new Guid("1420a446-4d7b-415f-bb4f-7b8f6f29a349") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("470571b0-857b-4383-878c-619596e6420f"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4cc637ef-845e-4e5b-8d9b-c9a7e7c2f9da"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6462f0fa-3755-4aa8-bda6-4a333eaafeed"));

            migrationBuilder.AlterColumn<string>(
                name: "Tags",
                schema: "dbo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "LastName", "Login", "Name", "Order", "Password", "Role", "TenantId" },
                values: new object[,]
                {
                    { new Guid("7718008b-13c0-4b7d-8cc2-4b984dd63079"), false, "sayala@music.com", "Ayala", "chucaro", "Santiago", 0L, "123", "Administrador", new Guid("863e9564-4b31-409d-805f-88465b949f5a") },
                    { new Guid("bec12fbd-e8a1-4330-9602-374ade1cc9b2"), false, "steve@apple.com", "Jobs", "steve", "Steve", 0L, "123", "Administrador", new Guid("00000001-0001-0001-0001-000000000001") },
                    { new Guid("d51dbeaa-5add-440c-8d0c-022caa4ab66d"), false, "jcafrune@music.com", "Cafrune", "turco", "Jorge", 0L, "123", "Administrador", new Guid("1420a446-4d7b-415f-bb4f-7b8f6f29a349") }
                });
        }
    }
}
