using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ChangeGameTableAgain2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("13e77d83-43c9-4c52-80eb-3a83f4700920"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("fa7e81a8-032d-4689-a067-7453484d6bb5"), "admin", new byte[] { 67, 11, 47, 185, 251, 46, 129, 4, 119, 116, 191, 199, 209, 250, 136, 229, 157, 213, 150, 249, 226, 98, 122, 92, 183, 158, 216, 199, 156, 98, 106, 18, 122, 70, 145, 159, 168, 69, 56, 204, 137, 89, 38, 229, 149, 107, 225, 142, 99, 213, 140, 97, 55, 103, 57, 111, 47, 172, 122, 207, 74, 159, 213, 87 }, new byte[] { 15, 212, 100, 170, 23, 255, 187, 140, 99, 213, 39, 34, 237, 211, 230, 164, 51, 27, 0, 47, 90, 241, 173, 146, 142, 88, 156, 49, 196, 44, 150, 212, 48, 2, 153, 31, 240, 235, 169, 44, 254, 164, 38, 21, 181, 92, 79, 145, 46, 179, 4, 15, 106, 222, 232, 162, 222, 23, 89, 25, 133, 205, 120, 33, 93, 233, 226, 157, 107, 12, 84, 17, 205, 124, 22, 143, 179, 145, 107, 126, 66, 5, 177, 140, 183, 48, 2, 159, 56, 79, 210, 144, 66, 59, 13, 19, 129, 83, 106, 234, 199, 23, 29, 9, 35, 226, 142, 209, 61, 216, 103, 112, 91, 204, 31, 200, 250, 132, 109, 107, 229, 209, 64, 245, 106, 139, 160, 189 }, "Admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("fa7e81a8-032d-4689-a067-7453484d6bb5"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("13e77d83-43c9-4c52-80eb-3a83f4700920"), "admin", new byte[] { 62, 144, 106, 113, 22, 212, 0, 82, 97, 189, 213, 165, 203, 70, 240, 21, 194, 64, 168, 186, 230, 36, 225, 83, 114, 97, 175, 171, 169, 7, 105, 167, 23, 42, 120, 40, 105, 9, 106, 248, 0, 48, 1, 168, 121, 50, 171, 18, 84, 185, 77, 191, 255, 209, 105, 196, 54, 98, 74, 189, 155, 230, 86, 119 }, new byte[] { 132, 177, 37, 212, 224, 188, 227, 98, 118, 98, 91, 176, 53, 183, 174, 32, 204, 69, 101, 194, 231, 107, 140, 217, 86, 81, 153, 134, 248, 153, 219, 86, 140, 203, 20, 220, 187, 66, 144, 0, 209, 40, 47, 87, 203, 94, 219, 118, 193, 119, 54, 111, 195, 160, 235, 83, 172, 206, 70, 9, 69, 216, 145, 69, 55, 8, 215, 196, 228, 195, 36, 156, 118, 162, 16, 11, 105, 70, 222, 235, 90, 134, 205, 251, 13, 197, 240, 109, 22, 145, 123, 117, 250, 65, 128, 91, 140, 68, 158, 41, 147, 125, 7, 43, 106, 19, 111, 77, 56, 54, 205, 187, 162, 238, 172, 137, 97, 36, 83, 187, 89, 72, 36, 121, 28, 197, 201, 161 }, "Admin", "admin" });
        }
    }
}
