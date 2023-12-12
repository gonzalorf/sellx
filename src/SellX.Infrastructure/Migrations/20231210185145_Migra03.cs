using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SellX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Migra03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0001-0001-000000000001"),
                column: "Name",
                value: "Gonzalo Tenant");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("1420a446-4d7b-415f-bb4f-7b8f6f29a349"),
                column: "Name",
                value: "Store Sur");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("863e9564-4b31-409d-805f-88465b949f5a"),
                column: "Name",
                value: "Store Norte");

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "LastName", "Login", "Name", "Order", "Password", "Role", "TenantId" },
                values: new object[,]
                {
                    { new Guid("2b12a886-9a38-45f3-9850-5ffb95774ca0"), false, "jcafrune@music.com", "Cafrune", "turco", "Jorge", 0L, "123", "Administrador", new Guid("1420a446-4d7b-415f-bb4f-7b8f6f29a349") },
                    { new Guid("7d5e1b37-2afe-4063-b4eb-c47f96458e32"), false, "gonzalorf@sellx.com", "Fernández", "gonzalo", "Gonzalo", 0L, "123", "Administrador", new Guid("00000001-0001-0001-0001-000000000001") },
                    { new Guid("95f224c9-0258-4272-9957-ea038942ae90"), false, "sayala@music.com", "Ayala", "chucaro", "Santiago", 0L, "123", "Administrador", new Guid("863e9564-4b31-409d-805f-88465b949f5a") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2b12a886-9a38-45f3-9850-5ffb95774ca0"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7d5e1b37-2afe-4063-b4eb-c47f96458e32"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("95f224c9-0258-4272-9957-ea038942ae90"));

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0001-0001-0001-000000000001"),
                column: "Name",
                value: "Cityplus Argentina");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("1420a446-4d7b-415f-bb4f-7b8f6f29a349"),
                column: "Name",
                value: "Municipalidad Sur");

            migrationBuilder.UpdateData(
                schema: "dbo",
                table: "Tenants",
                keyColumn: "Id",
                keyValue: new Guid("863e9564-4b31-409d-805f-88465b949f5a"),
                column: "Name",
                value: "Municipalidad Norte");

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
    }
}
