using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ChangePlaylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("533c819e-d18c-4a16-a5f4-32a9b5fcaefc"));

            migrationBuilder.AddColumn<int>(
                name: "blindGuessSongs",
                table: "MusicPlaylists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "blindGuessTime",
                table: "MusicPlaylists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lightningRoundSongs",
                table: "MusicPlaylists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "lightningRoundTime",
                table: "MusicPlaylists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username", "currentGameId" },
                values: new object[] { new Guid("e0e9f003-574c-4adf-b6bc-69845e7703ec"), "admin", new byte[] { 6, 89, 116, 226, 85, 241, 66, 9, 150, 54, 255, 242, 81, 39, 67, 201, 76, 84, 81, 12, 243, 56, 196, 194, 14, 47, 182, 112, 160, 141, 84, 29, 208, 214, 252, 86, 254, 60, 70, 233, 202, 233, 160, 94, 118, 164, 169, 190, 252, 158, 131, 115, 237, 85, 59, 32, 125, 179, 173, 78, 171, 116, 221, 9 }, new byte[] { 140, 37, 37, 34, 56, 182, 242, 241, 195, 172, 48, 244, 113, 165, 116, 177, 84, 62, 30, 212, 162, 24, 29, 202, 66, 165, 160, 10, 16, 116, 73, 250, 181, 51, 141, 16, 190, 122, 48, 49, 177, 157, 10, 111, 107, 65, 249, 123, 117, 136, 185, 22, 42, 73, 52, 174, 43, 0, 93, 11, 98, 43, 248, 48, 155, 62, 52, 9, 231, 186, 227, 253, 186, 145, 79, 82, 20, 233, 118, 63, 208, 163, 196, 157, 72, 17, 211, 217, 42, 203, 91, 10, 42, 34, 218, 84, 43, 156, 219, 230, 24, 24, 58, 129, 42, 94, 99, 8, 138, 146, 85, 94, 240, 148, 230, 105, 68, 200, 208, 156, 254, 166, 163, 193, 89, 50, 202, 59 }, "Admin", "admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("e0e9f003-574c-4adf-b6bc-69845e7703ec"));

            migrationBuilder.DropColumn(
                name: "blindGuessSongs",
                table: "MusicPlaylists");

            migrationBuilder.DropColumn(
                name: "blindGuessTime",
                table: "MusicPlaylists");

            migrationBuilder.DropColumn(
                name: "lightningRoundSongs",
                table: "MusicPlaylists");

            migrationBuilder.DropColumn(
                name: "lightningRoundTime",
                table: "MusicPlaylists");

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username", "currentGameId" },
                values: new object[] { new Guid("533c819e-d18c-4a16-a5f4-32a9b5fcaefc"), "admin", new byte[] { 58, 185, 106, 223, 89, 59, 250, 118, 25, 112, 50, 18, 167, 248, 255, 168, 198, 162, 176, 211, 240, 184, 76, 207, 196, 218, 131, 153, 152, 19, 164, 51, 222, 196, 216, 170, 210, 7, 47, 185, 42, 103, 106, 143, 157, 188, 144, 221, 131, 12, 193, 160, 90, 91, 6, 80, 174, 134, 9, 244, 125, 96, 238, 177 }, new byte[] { 196, 253, 84, 14, 201, 247, 85, 152, 177, 207, 195, 33, 23, 33, 8, 232, 55, 136, 248, 240, 1, 63, 172, 81, 214, 229, 211, 216, 112, 220, 154, 76, 226, 206, 130, 46, 158, 187, 217, 28, 112, 219, 52, 165, 26, 13, 48, 148, 119, 172, 245, 138, 50, 220, 88, 205, 138, 129, 122, 194, 178, 205, 48, 187, 218, 37, 172, 163, 224, 121, 92, 91, 29, 207, 254, 107, 143, 252, 250, 208, 250, 249, 245, 114, 41, 108, 213, 72, 90, 71, 106, 121, 216, 168, 106, 190, 3, 35, 69, 29, 144, 54, 136, 86, 251, 164, 32, 211, 63, 239, 178, 213, 96, 254, 162, 243, 231, 219, 18, 193, 38, 174, 172, 76, 161, 77, 247, 97 }, "Admin", "admin", null });
        }
    }
}
