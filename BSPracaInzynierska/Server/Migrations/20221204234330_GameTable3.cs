using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class GameTable3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("9bbeb874-b4ae-408c-ab94-1a45e34c1dbd"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "MultiGameId", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("5d27dc5e-bdfe-4cfd-9f1d-a1ff9f3ca043"), "admin", null, new byte[] { 211, 195, 191, 32, 29, 162, 61, 154, 21, 252, 1, 169, 231, 241, 228, 67, 67, 239, 232, 128, 136, 100, 62, 202, 51, 179, 215, 0, 209, 45, 190, 215, 254, 37, 156, 192, 106, 57, 124, 84, 65, 152, 8, 4, 191, 185, 205, 74, 27, 42, 99, 231, 59, 134, 199, 134, 204, 126, 36, 175, 0, 12, 190, 23 }, new byte[] { 3, 97, 236, 30, 118, 37, 63, 153, 21, 2, 254, 89, 108, 65, 143, 182, 37, 110, 79, 221, 254, 244, 201, 135, 206, 119, 106, 80, 183, 126, 40, 95, 213, 15, 189, 190, 195, 178, 71, 54, 234, 28, 112, 17, 146, 81, 215, 26, 65, 202, 76, 79, 12, 234, 219, 54, 196, 160, 242, 136, 255, 170, 146, 91, 218, 14, 216, 163, 168, 139, 116, 30, 164, 65, 179, 18, 92, 133, 50, 192, 109, 30, 62, 0, 182, 101, 104, 215, 64, 140, 84, 189, 214, 61, 143, 71, 15, 23, 29, 157, 216, 167, 62, 236, 126, 243, 29, 1, 134, 154, 183, 171, 68, 84, 210, 176, 144, 231, 211, 180, 53, 188, 29, 72, 227, 36, 81, 86 }, "Admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("5d27dc5e-bdfe-4cfd-9f1d-a1ff9f3ca043"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "MultiGameId", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("9bbeb874-b4ae-408c-ab94-1a45e34c1dbd"), "admin", null, new byte[] { 131, 31, 37, 196, 22, 92, 173, 219, 22, 168, 217, 217, 194, 193, 115, 197, 8, 182, 60, 104, 105, 136, 148, 124, 36, 175, 30, 227, 15, 221, 8, 85, 3, 148, 137, 93, 255, 166, 120, 168, 28, 195, 162, 228, 215, 26, 128, 219, 104, 79, 157, 235, 114, 86, 109, 133, 133, 170, 78, 188, 145, 253, 106, 223 }, new byte[] { 23, 71, 128, 140, 157, 51, 246, 63, 120, 20, 194, 99, 172, 1, 131, 7, 159, 41, 151, 129, 108, 153, 122, 70, 173, 36, 163, 85, 47, 248, 107, 7, 152, 225, 165, 229, 243, 239, 156, 251, 176, 172, 122, 106, 53, 153, 8, 217, 181, 248, 208, 4, 220, 169, 16, 72, 219, 140, 13, 174, 233, 217, 113, 81, 75, 254, 49, 41, 51, 252, 150, 73, 15, 252, 76, 207, 56, 94, 16, 244, 48, 252, 40, 116, 64, 158, 227, 133, 67, 246, 93, 219, 147, 119, 116, 196, 173, 121, 57, 157, 102, 154, 160, 14, 144, 228, 232, 100, 178, 166, 2, 25, 179, 60, 97, 58, 53, 136, 214, 41, 154, 60, 82, 104, 24, 77, 169, 70 }, "Admin", "admin" });
        }
    }
}
