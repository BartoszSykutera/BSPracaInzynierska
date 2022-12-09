using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ChangeGameTableAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Game_MultiGameId",
                table: "Uzytkownicy");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownicy_MultiGameId",
                table: "Uzytkownicy");

            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("5d27dc5e-bdfe-4cfd-9f1d-a1ff9f3ca043"));

            migrationBuilder.DropColumn(
                name: "MultiGameId",
                table: "Uzytkownicy");

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("13e77d83-43c9-4c52-80eb-3a83f4700920"), "admin", new byte[] { 62, 144, 106, 113, 22, 212, 0, 82, 97, 189, 213, 165, 203, 70, 240, 21, 194, 64, 168, 186, 230, 36, 225, 83, 114, 97, 175, 171, 169, 7, 105, 167, 23, 42, 120, 40, 105, 9, 106, 248, 0, 48, 1, 168, 121, 50, 171, 18, 84, 185, 77, 191, 255, 209, 105, 196, 54, 98, 74, 189, 155, 230, 86, 119 }, new byte[] { 132, 177, 37, 212, 224, 188, 227, 98, 118, 98, 91, 176, 53, 183, 174, 32, 204, 69, 101, 194, 231, 107, 140, 217, 86, 81, 153, 134, 248, 153, 219, 86, 140, 203, 20, 220, 187, 66, 144, 0, 209, 40, 47, 87, 203, 94, 219, 118, 193, 119, 54, 111, 195, 160, 235, 83, 172, 206, 70, 9, 69, 216, 145, 69, 55, 8, 215, 196, 228, 195, 36, 156, 118, 162, 16, 11, 105, 70, 222, 235, 90, 134, 205, 251, 13, 197, 240, 109, 22, 145, 123, 117, 250, 65, 128, 91, 140, 68, 158, 41, 147, 125, 7, 43, 106, 19, 111, 77, 56, 54, 205, 187, 162, 238, 172, 137, 97, 36, 83, 187, 89, 72, 36, 121, 28, 197, 201, 161 }, "Admin", "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("13e77d83-43c9-4c52-80eb-3a83f4700920"));

            migrationBuilder.AddColumn<Guid>(
                name: "MultiGameId",
                table: "Uzytkownicy",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "MultiGameId", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("5d27dc5e-bdfe-4cfd-9f1d-a1ff9f3ca043"), "admin", null, new byte[] { 211, 195, 191, 32, 29, 162, 61, 154, 21, 252, 1, 169, 231, 241, 228, 67, 67, 239, 232, 128, 136, 100, 62, 202, 51, 179, 215, 0, 209, 45, 190, 215, 254, 37, 156, 192, 106, 57, 124, 84, 65, 152, 8, 4, 191, 185, 205, 74, 27, 42, 99, 231, 59, 134, 199, 134, 204, 126, 36, 175, 0, 12, 190, 23 }, new byte[] { 3, 97, 236, 30, 118, 37, 63, 153, 21, 2, 254, 89, 108, 65, 143, 182, 37, 110, 79, 221, 254, 244, 201, 135, 206, 119, 106, 80, 183, 126, 40, 95, 213, 15, 189, 190, 195, 178, 71, 54, 234, 28, 112, 17, 146, 81, 215, 26, 65, 202, 76, 79, 12, 234, 219, 54, 196, 160, 242, 136, 255, 170, 146, 91, 218, 14, 216, 163, 168, 139, 116, 30, 164, 65, 179, 18, 92, 133, 50, 192, 109, 30, 62, 0, 182, 101, 104, 215, 64, 140, 84, 189, 214, 61, 143, 71, 15, 23, 29, 157, 216, 167, 62, 236, 126, 243, 29, 1, 134, 154, 183, 171, 68, 84, 210, 176, 144, 231, 211, 180, 53, 188, 29, 72, 227, 36, 81, 86 }, "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_MultiGameId",
                table: "Uzytkownicy",
                column: "MultiGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Game_MultiGameId",
                table: "Uzytkownicy",
                column: "MultiGameId",
                principalTable: "Game",
                principalColumn: "Id");
        }
    }
}
