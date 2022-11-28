using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ChangeJSON : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("10b6380d-e4dd-4046-9edf-cfb12899713a"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("08c3c7d6-0b2e-4021-b105-f7fc2288ffdd"), "admin", new byte[] { 164, 182, 173, 235, 110, 54, 134, 211, 139, 154, 173, 87, 186, 191, 209, 204, 119, 122, 68, 119, 0, 11, 5, 228, 196, 23, 70, 198, 27, 13, 162, 202, 76, 8, 77, 61, 66, 154, 76, 111, 224, 234, 185, 120, 107, 70, 76, 154, 173, 35, 77, 11, 25, 188, 76, 220, 58, 95, 142, 14, 121, 105, 205, 237 }, new byte[] { 38, 10, 205, 109, 178, 26, 66, 117, 164, 18, 150, 57, 82, 176, 130, 211, 228, 72, 169, 247, 167, 5, 149, 238, 188, 144, 9, 3, 109, 159, 185, 165, 233, 113, 104, 54, 128, 178, 205, 54, 111, 230, 248, 166, 102, 149, 200, 179, 61, 213, 192, 105, 234, 255, 108, 209, 187, 249, 153, 255, 5, 204, 77, 126, 20, 24, 5, 237, 246, 93, 73, 132, 6, 109, 241, 234, 211, 156, 61, 110, 146, 189, 157, 11, 19, 40, 109, 232, 189, 90, 238, 145, 4, 67, 44, 99, 0, 4, 11, 122, 154, 157, 139, 183, 86, 109, 132, 27, 11, 98, 75, 57, 237, 251, 48, 147, 53, 186, 163, 182, 35, 13, 128, 223, 216, 202, 97, 220 }, "Admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("08c3c7d6-0b2e-4021-b105-f7fc2288ffdd"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("10b6380d-e4dd-4046-9edf-cfb12899713a"), "admin", new byte[] { 54, 36, 29, 220, 182, 251, 205, 13, 73, 87, 230, 208, 11, 187, 165, 81, 79, 22, 117, 185, 21, 253, 89, 88, 2, 160, 167, 226, 179, 60, 218, 233, 51, 8, 179, 70, 209, 31, 218, 38, 229, 255, 98, 136, 67, 133, 189, 135, 65, 77, 241, 211, 17, 58, 137, 37, 95, 163, 111, 249, 135, 9, 191, 176 }, new byte[] { 15, 102, 110, 105, 195, 118, 23, 32, 202, 142, 135, 253, 215, 71, 228, 65, 151, 12, 31, 181, 85, 224, 120, 205, 88, 128, 77, 88, 186, 100, 53, 130, 71, 113, 16, 42, 29, 83, 184, 102, 76, 205, 25, 202, 230, 158, 194, 128, 43, 113, 116, 9, 239, 214, 147, 126, 8, 100, 90, 1, 233, 165, 23, 66, 128, 155, 34, 56, 163, 104, 45, 37, 215, 159, 220, 174, 44, 154, 113, 61, 64, 187, 214, 135, 89, 39, 80, 195, 194, 110, 15, 101, 123, 106, 124, 237, 152, 86, 241, 137, 146, 80, 117, 9, 102, 56, 197, 166, 172, 178, 9, 74, 190, 113, 110, 94, 186, 203, 65, 177, 66, 231, 178, 164, 217, 243, 195, 222 }, "Admin", "admin" });
        }
    }
}
