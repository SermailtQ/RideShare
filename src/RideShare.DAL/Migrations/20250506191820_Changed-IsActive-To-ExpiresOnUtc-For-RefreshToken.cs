using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RideShare.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangedIsActiveToExpiresOnUtcForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserRefreshTokens");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresOnUtc",
                table: "UserRefreshTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresOnUtc",
                table: "UserRefreshTokens");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserRefreshTokens",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
