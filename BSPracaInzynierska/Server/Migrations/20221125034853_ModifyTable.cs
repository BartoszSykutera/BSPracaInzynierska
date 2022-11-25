using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ModifyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("e6f2dfa2-a690-4ddd-9ac5-1953a0a551bf"));

            migrationBuilder.AlterColumn<int>(
                name: "points",
                table: "GameTypeOne",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("8451a417-249e-4d64-ae05-1f2b802645bc"), "admin", new byte[] { 149, 6, 64, 86, 187, 1, 238, 254, 6, 44, 16, 98, 173, 69, 165, 144, 123, 84, 201, 79, 10, 135, 120, 125, 121, 117, 3, 66, 232, 48, 63, 217, 102, 238, 39, 41, 210, 49, 190, 124, 71, 44, 145, 170, 39, 198, 84, 79, 209, 189, 182, 52, 2, 21, 176, 28, 221, 177, 235, 249, 128, 253, 208, 226 }, new byte[] { 63, 33, 126, 114, 13, 2, 147, 129, 182, 145, 77, 154, 225, 217, 108, 157, 81, 88, 223, 132, 182, 52, 216, 121, 250, 86, 177, 125, 192, 230, 173, 188, 41, 157, 2, 139, 245, 219, 166, 26, 13, 224, 32, 103, 200, 180, 93, 205, 129, 107, 3, 138, 139, 10, 58, 2, 16, 53, 58, 115, 174, 110, 143, 28, 162, 108, 110, 3, 15, 26, 63, 19, 87, 77, 0, 8, 135, 144, 179, 251, 27, 161, 198, 223, 52, 16, 40, 202, 17, 203, 95, 205, 238, 0, 239, 159, 215, 128, 0, 11, 214, 64, 213, 130, 4, 186, 17, 173, 8, 100, 107, 165, 250, 34, 156, 121, 32, 23, 180, 92, 236, 150, 229, 223, 147, 241, 91, 146 }, "Admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("8451a417-249e-4d64-ae05-1f2b802645bc"));

            migrationBuilder.AlterColumn<int>(
                name: "points",
                table: "GameTypeOne",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("e6f2dfa2-a690-4ddd-9ac5-1953a0a551bf"), "admin", new byte[] { 40, 26, 134, 20, 147, 67, 94, 174, 204, 217, 75, 226, 83, 154, 47, 246, 0, 165, 208, 40, 78, 33, 248, 36, 78, 247, 99, 34, 44, 82, 219, 48, 225, 193, 14, 51, 181, 100, 184, 221, 160, 37, 120, 3, 200, 237, 130, 251, 96, 196, 255, 102, 60, 49, 140, 65, 198, 62, 77, 34, 62, 130, 92, 81 }, new byte[] { 82, 120, 208, 251, 182, 103, 57, 71, 247, 232, 180, 191, 43, 194, 189, 219, 4, 146, 196, 166, 191, 217, 216, 147, 222, 198, 16, 128, 96, 0, 45, 55, 145, 194, 221, 29, 115, 103, 90, 221, 82, 1, 174, 76, 104, 72, 157, 92, 176, 228, 174, 173, 238, 203, 24, 52, 51, 106, 214, 84, 71, 125, 108, 16, 255, 77, 244, 99, 11, 99, 190, 84, 231, 142, 103, 21, 241, 21, 201, 182, 224, 84, 175, 66, 138, 15, 76, 226, 23, 193, 159, 95, 247, 128, 240, 176, 107, 2, 239, 80, 153, 25, 248, 148, 196, 174, 169, 34, 213, 9, 154, 144, 173, 173, 104, 112, 193, 157, 176, 66, 72, 188, 70, 144, 17, 4, 80, 242 }, "Admin", "admin" });
        }
    }
}
