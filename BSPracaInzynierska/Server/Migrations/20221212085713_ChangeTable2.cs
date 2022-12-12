using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ChangeTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("cb043ba0-7d01-420a-a5d7-5102f0e1446e"));

            migrationBuilder.AlterColumn<double>(
                name: "playerTime",
                table: "LeaderBoard",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Points",
                table: "LeaderBoard",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username", "currentGameId" },
                values: new object[] { new Guid("334c644f-367d-426f-b2ca-bfbd279858f3"), "admin", new byte[] { 180, 195, 99, 116, 110, 46, 191, 6, 123, 18, 88, 49, 100, 240, 31, 37, 254, 125, 236, 187, 90, 69, 233, 81, 194, 24, 33, 55, 128, 49, 250, 178, 204, 105, 209, 254, 238, 132, 75, 227, 170, 250, 240, 152, 41, 46, 138, 232, 243, 57, 202, 202, 42, 143, 175, 34, 3, 17, 53, 196, 64, 93, 230, 98 }, new byte[] { 119, 174, 14, 18, 167, 99, 251, 216, 10, 196, 152, 8, 136, 130, 18, 154, 255, 241, 175, 75, 191, 187, 121, 222, 180, 78, 158, 209, 194, 140, 198, 203, 67, 152, 32, 55, 254, 240, 126, 61, 224, 246, 18, 150, 42, 107, 84, 57, 99, 7, 86, 6, 73, 67, 176, 73, 236, 36, 223, 165, 76, 159, 182, 111, 215, 161, 244, 115, 85, 13, 86, 20, 104, 150, 138, 82, 198, 130, 33, 76, 144, 13, 63, 249, 175, 234, 123, 239, 253, 112, 190, 91, 112, 182, 63, 49, 74, 68, 149, 145, 104, 40, 69, 239, 79, 41, 248, 98, 63, 236, 127, 153, 110, 204, 121, 157, 53, 165, 41, 147, 233, 121, 178, 171, 244, 39, 68, 191 }, "Admin", "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("334c644f-367d-426f-b2ca-bfbd279858f3"));

            migrationBuilder.AlterColumn<double>(
                name: "playerTime",
                table: "LeaderBoard",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Points",
                table: "LeaderBoard",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username", "currentGameId" },
                values: new object[] { new Guid("cb043ba0-7d01-420a-a5d7-5102f0e1446e"), "admin", new byte[] { 225, 241, 208, 21, 58, 89, 112, 253, 149, 221, 45, 80, 171, 123, 13, 103, 103, 163, 68, 247, 109, 143, 164, 20, 217, 0, 203, 97, 75, 202, 193, 24, 127, 195, 252, 188, 71, 114, 80, 161, 113, 166, 167, 73, 105, 148, 202, 110, 64, 64, 190, 206, 207, 173, 232, 140, 41, 129, 68, 117, 218, 251, 179, 31 }, new byte[] { 143, 194, 119, 30, 224, 113, 232, 179, 33, 127, 213, 154, 72, 120, 182, 98, 173, 122, 140, 29, 39, 42, 251, 80, 129, 172, 231, 182, 190, 104, 151, 139, 17, 52, 68, 97, 63, 250, 184, 235, 105, 126, 83, 27, 136, 65, 21, 175, 194, 97, 85, 130, 183, 42, 199, 65, 247, 201, 103, 149, 204, 114, 236, 137, 80, 119, 144, 225, 125, 117, 27, 212, 218, 25, 193, 120, 54, 23, 128, 233, 241, 106, 228, 219, 190, 250, 65, 108, 31, 151, 18, 172, 38, 79, 231, 60, 182, 155, 250, 138, 213, 237, 15, 168, 199, 12, 80, 11, 25, 156, 9, 93, 72, 13, 64, 12, 211, 200, 81, 132, 237, 182, 145, 193, 54, 185, 186, 135 }, "Admin", "admin", null });
        }
    }
}
