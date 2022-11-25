using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ModifyTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("d0713188-eb05-4af5-a30b-9817698b40b3"));

            migrationBuilder.AddColumn<int>(
                name: "gameTime",
                table: "GameTypeOne",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("10b6380d-e4dd-4046-9edf-cfb12899713a"), "admin", new byte[] { 54, 36, 29, 220, 182, 251, 205, 13, 73, 87, 230, 208, 11, 187, 165, 81, 79, 22, 117, 185, 21, 253, 89, 88, 2, 160, 167, 226, 179, 60, 218, 233, 51, 8, 179, 70, 209, 31, 218, 38, 229, 255, 98, 136, 67, 133, 189, 135, 65, 77, 241, 211, 17, 58, 137, 37, 95, 163, 111, 249, 135, 9, 191, 176 }, new byte[] { 15, 102, 110, 105, 195, 118, 23, 32, 202, 142, 135, 253, 215, 71, 228, 65, 151, 12, 31, 181, 85, 224, 120, 205, 88, 128, 77, 88, 186, 100, 53, 130, 71, 113, 16, 42, 29, 83, 184, 102, 76, 205, 25, 202, 230, 158, 194, 128, 43, 113, 116, 9, 239, 214, 147, 126, 8, 100, 90, 1, 233, 165, 23, 66, 128, 155, 34, 56, 163, 104, 45, 37, 215, 159, 220, 174, 44, 154, 113, 61, 64, 187, 214, 135, 89, 39, 80, 195, 194, 110, 15, 101, 123, 106, 124, 237, 152, 86, 241, 137, 146, 80, 117, 9, 102, 56, 197, 166, 172, 178, 9, 74, 190, 113, 110, 94, 186, 203, 65, 177, 66, 231, 178, 164, 217, 243, 195, 222 }, "Admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("10b6380d-e4dd-4046-9edf-cfb12899713a"));

            migrationBuilder.DropColumn(
                name: "gameTime",
                table: "GameTypeOne");

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("d0713188-eb05-4af5-a30b-9817698b40b3"), "admin", new byte[] { 9, 22, 77, 186, 91, 128, 231, 144, 25, 215, 113, 99, 42, 29, 62, 215, 36, 182, 176, 26, 29, 115, 71, 86, 213, 99, 39, 53, 229, 77, 108, 192, 149, 14, 251, 82, 55, 76, 91, 152, 125, 109, 69, 245, 152, 149, 86, 23, 243, 248, 9, 148, 164, 248, 183, 90, 125, 102, 215, 67, 122, 12, 50, 66 }, new byte[] { 162, 146, 102, 247, 178, 102, 251, 154, 170, 91, 66, 248, 157, 232, 124, 83, 221, 185, 72, 53, 46, 13, 106, 35, 231, 7, 90, 9, 134, 203, 65, 225, 241, 81, 153, 168, 211, 137, 56, 128, 213, 14, 82, 63, 218, 42, 93, 53, 138, 42, 140, 232, 207, 0, 158, 75, 230, 252, 85, 9, 69, 243, 222, 110, 215, 30, 186, 176, 202, 203, 174, 195, 153, 244, 36, 235, 122, 57, 167, 149, 60, 217, 59, 65, 152, 72, 167, 67, 6, 242, 170, 153, 29, 254, 136, 231, 119, 100, 27, 213, 67, 204, 177, 10, 182, 233, 27, 104, 83, 240, 92, 85, 159, 15, 16, 82, 89, 19, 130, 108, 195, 147, 214, 12, 77, 82, 175, 102 }, "Admin", "admin" });
        }
    }
}
