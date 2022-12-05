using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class GameTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("08c3c7d6-0b2e-4021-b105-f7fc2288ffdd"));

            migrationBuilder.DropColumn(
                name: "GameTypeOneId",
                table: "Songs");

            migrationBuilder.AddColumn<Guid>(
                name: "MultiGameId",
                table: "Uzytkownicy",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumberOfTracks = table.Column<int>(type: "int", nullable: false),
                    gameTime = table.Column<double>(type: "float", nullable: false),
                    PlaylistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserHost = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_MusicPlaylists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "MusicPlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "MultiGameId", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("9bbeb874-b4ae-408c-ab94-1a45e34c1dbd"), "admin", null, new byte[] { 131, 31, 37, 196, 22, 92, 173, 219, 22, 168, 217, 217, 194, 193, 115, 197, 8, 182, 60, 104, 105, 136, 148, 124, 36, 175, 30, 227, 15, 221, 8, 85, 3, 148, 137, 93, 255, 166, 120, 168, 28, 195, 162, 228, 215, 26, 128, 219, 104, 79, 157, 235, 114, 86, 109, 133, 133, 170, 78, 188, 145, 253, 106, 223 }, new byte[] { 23, 71, 128, 140, 157, 51, 246, 63, 120, 20, 194, 99, 172, 1, 131, 7, 159, 41, 151, 129, 108, 153, 122, 70, 173, 36, 163, 85, 47, 248, 107, 7, 152, 225, 165, 229, 243, 239, 156, 251, 176, 172, 122, 106, 53, 153, 8, 217, 181, 248, 208, 4, 220, 169, 16, 72, 219, 140, 13, 174, 233, 217, 113, 81, 75, 254, 49, 41, 51, 252, 150, 73, 15, 252, 76, 207, 56, 94, 16, 244, 48, 252, 40, 116, 64, 158, 227, 133, 67, 246, 93, 219, 147, 119, 116, 196, 173, 121, 57, 157, 102, 154, 160, 14, 144, 228, 232, 100, 178, 166, 2, 25, 179, 60, 97, 58, 53, 136, 214, 41, 154, 60, 82, 104, 24, 77, 169, 70 }, "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_MultiGameId",
                table: "Uzytkownicy",
                column: "MultiGameId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlaylistId",
                table: "Game",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Uzytkownicy_Game_MultiGameId",
                table: "Uzytkownicy",
                column: "MultiGameId",
                principalTable: "Game",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uzytkownicy_Game_MultiGameId",
                table: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownicy_MultiGameId",
                table: "Uzytkownicy");

            migrationBuilder.DeleteData(
                table: "Uzytkownicy",
                keyColumn: "Id",
                keyValue: new Guid("9bbeb874-b4ae-408c-ab94-1a45e34c1dbd"));

            migrationBuilder.DropColumn(
                name: "MultiGameId",
                table: "Uzytkownicy");

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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NumberOfTracks = table.Column<int>(type: "int", nullable: false),
                    gameTime = table.Column<int>(type: "int", nullable: true),
                    points = table.Column<int>(type: "int", nullable: true)
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
                values: new object[] { new Guid("08c3c7d6-0b2e-4021-b105-f7fc2288ffdd"), "admin", new byte[] { 164, 182, 173, 235, 110, 54, 134, 211, 139, 154, 173, 87, 186, 191, 209, 204, 119, 122, 68, 119, 0, 11, 5, 228, 196, 23, 70, 198, 27, 13, 162, 202, 76, 8, 77, 61, 66, 154, 76, 111, 224, 234, 185, 120, 107, 70, 76, 154, 173, 35, 77, 11, 25, 188, 76, 220, 58, 95, 142, 14, 121, 105, 205, 237 }, new byte[] { 38, 10, 205, 109, 178, 26, 66, 117, 164, 18, 150, 57, 82, 176, 130, 211, 228, 72, 169, 247, 167, 5, 149, 238, 188, 144, 9, 3, 109, 159, 185, 165, 233, 113, 104, 54, 128, 178, 205, 54, 111, 230, 248, 166, 102, 149, 200, 179, 61, 213, 192, 105, 234, 255, 108, 209, 187, 249, 153, 255, 5, 204, 77, 126, 20, 24, 5, 237, 246, 93, 73, 132, 6, 109, 241, 234, 211, 156, 61, 110, 146, 189, 157, 11, 19, 40, 109, 232, 189, 90, 238, 145, 4, 67, 44, 99, 0, 4, 11, 122, 154, 157, 139, 183, 86, 109, 132, 27, 11, 98, 75, 57, 237, 251, 48, 147, 53, 186, 163, 182, 35, 13, 128, 223, 216, 202, 97, 220 }, "Admin", "admin" });

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
    }
}
