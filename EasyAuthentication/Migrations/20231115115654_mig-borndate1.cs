using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class migborndate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BornDateTime",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("05446344-f9cc-4566-bd2c-36791b4e28ed"),
                columns: new[] { "BornDateTime", "DateTime", "Key", "Password", "UpdateDateTime" },
                values: new object[] { null, new DateTime(2023, 11, 15, 15, 26, 54, 299, DateTimeKind.Local).AddTicks(2814), "u8UXLttWEG", "A7-FF-05-A8-09-68-22-D9-B0-41-8A-34-90-9A-78-DC", new DateTime(2023, 11, 15, 15, 26, 54, 299, DateTimeKind.Local).AddTicks(2826) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BornDateTime",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("05446344-f9cc-4566-bd2c-36791b4e28ed"),
                columns: new[] { "DateTime", "Key", "Password", "UpdateDateTime" },
                values: new object[] { new DateTime(2023, 10, 31, 16, 51, 34, 117, DateTimeKind.Local).AddTicks(8018), "FZw9OmzGP5", "9A-A0-6F-24-90-12-E3-E5-AC-E1-58-FC-39-F0-2A-C9", new DateTime(2023, 10, 31, 16, 51, 34, 117, DateTimeKind.Local).AddTicks(8028) });
        }
    }
}
