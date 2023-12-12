using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAuthentication.Migrations
{
    /// <inheritdoc />
    public partial class usergender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("05446344-f9cc-4566-bd2c-36791b4e28ed"),
                columns: new[] { "DateTime", "Gender", "Key", "Password", "UpdateDateTime" },
                values: new object[] { new DateTime(2023, 11, 15, 19, 41, 51, 385, DateTimeKind.Local).AddTicks(5216), null, "79hm0hQgOZ", "5E-5C-46-C5-33-52-74-7F-2F-FC-B0-26-CD-FA-E3-CE", new DateTime(2023, 11, 15, 19, 41, 51, 385, DateTimeKind.Local).AddTicks(5228) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("05446344-f9cc-4566-bd2c-36791b4e28ed"),
                columns: new[] { "DateTime", "Key", "Password", "UpdateDateTime" },
                values: new object[] { new DateTime(2023, 11, 15, 15, 26, 54, 299, DateTimeKind.Local).AddTicks(2814), "u8UXLttWEG", "A7-FF-05-A8-09-68-22-D9-B0-41-8A-34-90-9A-78-DC", new DateTime(2023, 11, 15, 15, 26, 54, 299, DateTimeKind.Local).AddTicks(2826) });
        }
    }
}
