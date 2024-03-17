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
                keyValue: new Guid("86422802-3ce6-4030-a87f-2cb1112f1a16"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("871c5f71-30e3-406e-9f07-c64ad88b3877"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b31b831e-2e30-4696-8cf6-d7deb234c7a4"));

            migrationBuilder.CreateTable(
                name: "Providers",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    BankAccountAlias = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Order = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "LastName", "Login", "Name", "Order", "Password", "Role", "TenantId" },
                values: new object[,]
                {
                    { new Guid("43b29311-77cc-4b44-bee8-17643844d9e2"), false, "sayala@music.com", "Ayala", "chucaro", "Santiago", 0L, "123", "Administrador", new Guid("863e9564-4b31-409d-805f-88465b949f5a") },
                    { new Guid("cbaca590-457d-456d-b9af-6b994155ab6c"), false, "jcafrune@music.com", "Cafrune", "turco", "Jorge", 0L, "123", "Administrador", new Guid("1420a446-4d7b-415f-bb4f-7b8f6f29a349") },
                    { new Guid("e7769289-eb4e-47f4-ae62-4861347dfd81"), false, "gonzalorf@sellx.com", "Fernández", "gonzalo", "Gonzalo", 0L, "123", "Administrador", new Guid("00000001-0001-0001-0001-000000000001") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Providers",
                schema: "dbo");

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("43b29311-77cc-4b44-bee8-17643844d9e2"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cbaca590-457d-456d-b9af-6b994155ab6c"));

            migrationBuilder.DeleteData(
                schema: "dbo",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e7769289-eb4e-47f4-ae62-4861347dfd81"));

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Users",
                columns: new[] { "Id", "Deleted", "Email", "LastName", "Login", "Name", "Order", "Password", "Role", "TenantId" },
                values: new object[,]
                {
                    { new Guid("86422802-3ce6-4030-a87f-2cb1112f1a16"), false, "sayala@music.com", "Ayala", "chucaro", "Santiago", 0L, "123", "Administrador", new Guid("863e9564-4b31-409d-805f-88465b949f5a") },
                    { new Guid("871c5f71-30e3-406e-9f07-c64ad88b3877"), false, "gonzalorf@sellx.com", "Fernández", "gonzalo", "Gonzalo", 0L, "123", "Administrador", new Guid("00000001-0001-0001-0001-000000000001") },
                    { new Guid("b31b831e-2e30-4696-8cf6-d7deb234c7a4"), false, "jcafrune@music.com", "Cafrune", "turco", "Jorge", 0L, "123", "Administrador", new Guid("1420a446-4d7b-415f-bb4f-7b8f6f29a349") }
                });
        }
    }
}
