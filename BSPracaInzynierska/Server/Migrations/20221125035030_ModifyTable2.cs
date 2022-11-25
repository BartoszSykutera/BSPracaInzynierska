using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ModifyTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("8451a417-249e-4d64-ae05-1f2b802645bc"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("d0713188-eb05-4af5-a30b-9817698b40b3"), "admin", new byte[] { 9, 22, 77, 186, 91, 128, 231, 144, 25, 215, 113, 99, 42, 29, 62, 215, 36, 182, 176, 26, 29, 115, 71, 86, 213, 99, 39, 53, 229, 77, 108, 192, 149, 14, 251, 82, 55, 76, 91, 152, 125, 109, 69, 245, 152, 149, 86, 23, 243, 248, 9, 148, 164, 248, 183, 90, 125, 102, 215, 67, 122, 12, 50, 66 }, new byte[] { 162, 146, 102, 247, 178, 102, 251, 154, 170, 91, 66, 248, 157, 232, 124, 83, 221, 185, 72, 53, 46, 13, 106, 35, 231, 7, 90, 9, 134, 203, 65, 225, 241, 81, 153, 168, 211, 137, 56, 128, 213, 14, 82, 63, 218, 42, 93, 53, 138, 42, 140, 232, 207, 0, 158, 75, 230, 252, 85, 9, 69, 243, 222, 110, 215, 30, 186, 176, 202, 203, 174, 195, 153, 244, 36, 235, 122, 57, 167, 149, 60, 217, 59, 65, 152, 72, 167, 67, 6, 242, 170, 153, 29, 254, 136, 231, 119, 100, 27, 213, 67, 204, 177, 10, 182, 233, 27, 104, 83, 240, 92, 85, 159, 15, 16, 82, 89, 19, 130, 108, 195, 147, 214, 12, 77, 82, 175, 102 }, "Admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("d0713188-eb05-4af5-a30b-9817698b40b3"));

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("8451a417-249e-4d64-ae05-1f2b802645bc"), "admin", new byte[] { 149, 6, 64, 86, 187, 1, 238, 254, 6, 44, 16, 98, 173, 69, 165, 144, 123, 84, 201, 79, 10, 135, 120, 125, 121, 117, 3, 66, 232, 48, 63, 217, 102, 238, 39, 41, 210, 49, 190, 124, 71, 44, 145, 170, 39, 198, 84, 79, 209, 189, 182, 52, 2, 21, 176, 28, 221, 177, 235, 249, 128, 253, 208, 226 }, new byte[] { 63, 33, 126, 114, 13, 2, 147, 129, 182, 145, 77, 154, 225, 217, 108, 157, 81, 88, 223, 132, 182, 52, 216, 121, 250, 86, 177, 125, 192, 230, 173, 188, 41, 157, 2, 139, 245, 219, 166, 26, 13, 224, 32, 103, 200, 180, 93, 205, 129, 107, 3, 138, 139, 10, 58, 2, 16, 53, 58, 115, 174, 110, 143, 28, 162, 108, 110, 3, 15, 26, 63, 19, 87, 77, 0, 8, 135, 144, 179, 251, 27, 161, 198, 223, 52, 16, 40, 202, 17, 203, 95, 205, 238, 0, 239, 159, 215, 128, 0, 11, 214, 64, 213, 130, 4, 186, 17, 173, 8, 100, 107, 165, 250, 34, 156, 121, 32, 23, 180, 92, 236, 150, 229, 223, 147, 241, 91, 146 }, "Admin", "admin" });
        }
    }
}
