using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ChangeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("98d2e1e9-73af-4bb7-a91d-e90531310bd5"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username", "currentGameId" },
                values: new object[] { new Guid("cb043ba0-7d01-420a-a5d7-5102f0e1446e"), "admin", new byte[] { 225, 241, 208, 21, 58, 89, 112, 253, 149, 221, 45, 80, 171, 123, 13, 103, 103, 163, 68, 247, 109, 143, 164, 20, 217, 0, 203, 97, 75, 202, 193, 24, 127, 195, 252, 188, 71, 114, 80, 161, 113, 166, 167, 73, 105, 148, 202, 110, 64, 64, 190, 206, 207, 173, 232, 140, 41, 129, 68, 117, 218, 251, 179, 31 }, new byte[] { 143, 194, 119, 30, 224, 113, 232, 179, 33, 127, 213, 154, 72, 120, 182, 98, 173, 122, 140, 29, 39, 42, 251, 80, 129, 172, 231, 182, 190, 104, 151, 139, 17, 52, 68, 97, 63, 250, 184, 235, 105, 126, 83, 27, 136, 65, 21, 175, 194, 97, 85, 130, 183, 42, 199, 65, 247, 201, 103, 149, 204, 114, 236, 137, 80, 119, 144, 225, 125, 117, 27, 212, 218, 25, 193, 120, 54, 23, 128, 233, 241, 106, 228, 219, 190, 250, 65, 108, 31, 151, 18, 172, 38, 79, 231, 60, 182, 155, 250, 138, 213, 237, 15, 168, 199, 12, 80, 11, 25, 156, 9, 93, 72, 13, 64, 12, 211, 200, 81, 132, 237, 182, 145, 193, 54, 185, 186, 135 }, "Admin", "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("cb043ba0-7d01-420a-a5d7-5102f0e1446e"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username", "currentGameId" },
                values: new object[] { new Guid("98d2e1e9-73af-4bb7-a91d-e90531310bd5"), "admin", new byte[] { 96, 148, 174, 107, 202, 163, 130, 14, 200, 120, 16, 189, 124, 36, 127, 175, 19, 125, 19, 81, 2, 14, 120, 69, 55, 27, 96, 29, 99, 96, 95, 64, 101, 145, 132, 182, 185, 186, 6, 18, 88, 216, 71, 80, 50, 179, 187, 81, 35, 134, 100, 100, 0, 112, 204, 146, 211, 226, 47, 177, 126, 143, 254, 230 }, new byte[] { 134, 81, 31, 246, 235, 31, 136, 163, 149, 84, 130, 133, 223, 172, 185, 194, 183, 210, 167, 111, 201, 144, 169, 196, 30, 18, 86, 43, 53, 246, 73, 75, 59, 190, 36, 83, 124, 42, 59, 209, 172, 131, 9, 91, 120, 26, 68, 51, 88, 35, 212, 149, 63, 175, 18, 228, 84, 181, 196, 221, 107, 220, 215, 33, 0, 119, 72, 223, 56, 178, 32, 27, 204, 151, 172, 70, 70, 132, 151, 213, 209, 241, 4, 42, 128, 43, 59, 82, 150, 241, 130, 105, 71, 54, 172, 244, 92, 219, 9, 124, 101, 172, 23, 172, 86, 210, 19, 112, 66, 22, 0, 210, 143, 181, 69, 252, 219, 74, 187, 127, 88, 79, 72, 179, 234, 99, 234, 15 }, "Admin", "admin", null });
        }
    }
}
