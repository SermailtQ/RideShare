using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RideShare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedForRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("3bac86d1-bb1d-41e3-ac0c-bd2f0058359e"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Passager who can book rides", "Passager", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("83700286-0449-41c2-84c9-39f08e5f60b9"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "User who can offer rides", "Driver", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("be2d2e92-f827-4058-aae8-f87be14b84e9"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Administrator with full access", "Admin", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("3bac86d1-bb1d-41e3-ac0c-bd2f0058359e"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("83700286-0449-41c2-84c9-39f08e5f60b9"));

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: new Guid("be2d2e92-f827-4058-aae8-f87be14b84e9"));
        }
    }
}
