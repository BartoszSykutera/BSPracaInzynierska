using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class AddGameType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("e0e9f003-574c-4adf-b6bc-69845e7703ec"));

            migrationBuilder.AddColumn<string>(
                name: "gameType",
                table: "LeaderBoard",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username", "currentGameId" },
                values: new object[] { new Guid("98d2e1e9-73af-4bb7-a91d-e90531310bd5"), "admin", new byte[] { 96, 148, 174, 107, 202, 163, 130, 14, 200, 120, 16, 189, 124, 36, 127, 175, 19, 125, 19, 81, 2, 14, 120, 69, 55, 27, 96, 29, 99, 96, 95, 64, 101, 145, 132, 182, 185, 186, 6, 18, 88, 216, 71, 80, 50, 179, 187, 81, 35, 134, 100, 100, 0, 112, 204, 146, 211, 226, 47, 177, 126, 143, 254, 230 }, new byte[] { 134, 81, 31, 246, 235, 31, 136, 163, 149, 84, 130, 133, 223, 172, 185, 194, 183, 210, 167, 111, 201, 144, 169, 196, 30, 18, 86, 43, 53, 246, 73, 75, 59, 190, 36, 83, 124, 42, 59, 209, 172, 131, 9, 91, 120, 26, 68, 51, 88, 35, 212, 149, 63, 175, 18, 228, 84, 181, 196, 221, 107, 220, 215, 33, 0, 119, 72, 223, 56, 178, 32, 27, 204, 151, 172, 70, 70, 132, 151, 213, 209, 241, 4, 42, 128, 43, 59, 82, 150, 241, 130, 105, 71, 54, 172, 244, 92, 219, 9, 124, 101, 172, 23, 172, 86, 210, 19, 112, 66, 22, 0, 210, 143, 181, 69, 252, 219, 74, 187, 127, 88, 79, 72, 179, 234, 99, 234, 15 }, "Admin", "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("98d2e1e9-73af-4bb7-a91d-e90531310bd5"));

            migrationBuilder.DropColumn(
                name: "gameType",
                table: "LeaderBoard");

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username", "currentGameId" },
                values: new object[] { new Guid("e0e9f003-574c-4adf-b6bc-69845e7703ec"), "admin", new byte[] { 6, 89, 116, 226, 85, 241, 66, 9, 150, 54, 255, 242, 81, 39, 67, 201, 76, 84, 81, 12, 243, 56, 196, 194, 14, 47, 182, 112, 160, 141, 84, 29, 208, 214, 252, 86, 254, 60, 70, 233, 202, 233, 160, 94, 118, 164, 169, 190, 252, 158, 131, 115, 237, 85, 59, 32, 125, 179, 173, 78, 171, 116, 221, 9 }, new byte[] { 140, 37, 37, 34, 56, 182, 242, 241, 195, 172, 48, 244, 113, 165, 116, 177, 84, 62, 30, 212, 162, 24, 29, 202, 66, 165, 160, 10, 16, 116, 73, 250, 181, 51, 141, 16, 190, 122, 48, 49, 177, 157, 10, 111, 107, 65, 249, 123, 117, 136, 185, 22, 42, 73, 52, 174, 43, 0, 93, 11, 98, 43, 248, 48, 155, 62, 52, 9, 231, 186, 227, 253, 186, 145, 79, 82, 20, 233, 118, 63, 208, 163, 196, 157, 72, 17, 211, 217, 42, 203, 91, 10, 42, 34, 218, 84, 43, 156, 219, 230, 24, 24, 58, 129, 42, 94, 99, 8, 138, 146, 85, 94, 240, 148, 230, 105, 68, 200, 208, 156, 254, 166, 163, 193, 89, 50, 202, 59 }, "Admin", "admin", null });
        }
    }
}
