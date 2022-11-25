using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class GameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("c7d5f84c-eb0c-40de-aa92-17d7685e7845"));

            migrationBuilder.AddColumn<Guid>(
                name: "GameTypeOneId",
                table: "Songs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameTypeOne",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfTracks = table.Column<int>(type: "int", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTypeOne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameTypeOne_Uzytkownicy_UserId",
                        column: x => x.UserId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("e6f2dfa2-a690-4ddd-9ac5-1953a0a551bf"), "admin", new byte[] { 40, 26, 134, 20, 147, 67, 94, 174, 204, 217, 75, 226, 83, 154, 47, 246, 0, 165, 208, 40, 78, 33, 248, 36, 78, 247, 99, 34, 44, 82, 219, 48, 225, 193, 14, 51, 181, 100, 184, 221, 160, 37, 120, 3, 200, 237, 130, 251, 96, 196, 255, 102, 60, 49, 140, 65, 198, 62, 77, 34, 62, 130, 92, 81 }, new byte[] { 82, 120, 208, 251, 182, 103, 57, 71, 247, 232, 180, 191, 43, 194, 189, 219, 4, 146, 196, 166, 191, 217, 216, 147, 222, 198, 16, 128, 96, 0, 45, 55, 145, 194, 221, 29, 115, 103, 90, 221, 82, 1, 174, 76, 104, 72, 157, 92, 176, 228, 174, 173, 238, 203, 24, 52, 51, 106, 214, 84, 71, 125, 108, 16, 255, 77, 244, 99, 11, 99, 190, 84, 231, 142, 103, 21, 241, 21, 201, 182, 224, 84, 175, 66, 138, 15, 76, 226, 23, 193, 159, 95, 247, 128, 240, 176, 107, 2, 239, 80, 153, 25, 248, 148, 196, 174, 169, 34, 213, 9, 154, 144, 173, 173, 104, 112, 193, 157, 176, 66, 72, 188, 70, 144, 17, 4, 80, 242 }, "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_GameTypeOneId",
                table: "Songs",
                column: "GameTypeOneId");

            migrationBuilder.CreateIndex(
                name: "IX_GameTypeOne_UserId",
                table: "GameTypeOne",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_GameTypeOne_GameTypeOneId",
                table: "Songs",
                column: "GameTypeOneId",
                principalTable: "GameTypeOne",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_GameTypeOne_GameTypeOneId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "GameTypeOne");

            migrationBuilder.DropIndex(
                name: "IX_Songs_GameTypeOneId",
                table: "Songs");

            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("e6f2dfa2-a690-4ddd-9ac5-1953a0a551bf"));

            migrationBuilder.DropColumn(
                name: "GameTypeOneId",
                table: "Songs");

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("c7d5f84c-eb0c-40de-aa92-17d7685e7845"), "admin", new byte[] { 198, 101, 72, 154, 221, 6, 201, 13, 214, 29, 84, 126, 64, 86, 150, 91, 240, 32, 145, 33, 31, 65, 244, 47, 190, 166, 109, 197, 6, 5, 223, 76, 225, 84, 58, 1, 111, 244, 56, 101, 240, 222, 215, 179, 114, 47, 61, 74, 121, 119, 227, 155, 150, 117, 171, 221, 229, 158, 168, 220, 102, 245, 9, 56 }, new byte[] { 121, 201, 107, 114, 53, 238, 226, 163, 54, 53, 131, 214, 179, 39, 196, 176, 151, 21, 73, 173, 104, 122, 218, 17, 62, 233, 67, 97, 14, 19, 137, 190, 205, 102, 181, 44, 227, 34, 8, 203, 43, 205, 88, 51, 210, 184, 229, 42, 28, 254, 231, 15, 170, 145, 181, 197, 227, 165, 214, 154, 246, 179, 215, 52, 93, 167, 133, 10, 177, 68, 180, 125, 67, 169, 213, 29, 158, 34, 242, 183, 86, 127, 50, 90, 2, 218, 53, 25, 166, 238, 179, 72, 10, 120, 147, 163, 194, 211, 5, 27, 27, 121, 89, 242, 199, 236, 163, 160, 116, 143, 206, 41, 144, 45, 168, 243, 148, 65, 123, 193, 253, 233, 135, 229, 212, 169, 87, 71 }, "Admin", "admin" });
        }
    }
}
