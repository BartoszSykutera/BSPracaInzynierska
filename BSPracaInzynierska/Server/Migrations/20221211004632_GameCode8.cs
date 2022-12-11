using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class GameCode8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    currentGameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uzytkownicy_Game_currentGameId",
                        column: x => x.currentGameId,
                        principalTable: "Game",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusicPlaylists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaylistName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfTracks = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicPlaylists_Uzytkownicy_UserId",
                        column: x => x.UserId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SongDuration = table.Column<int>(type: "int", nullable: true),
                    PlaylistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    YTVideoTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YTVidoeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YTChanelName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_MusicPlaylists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "MusicPlaylists",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username", "currentGameId" },
                values: new object[] { new Guid("dd25ec7c-aa8e-4204-b5b5-a136865ce00c"), "admin", new byte[] { 128, 43, 230, 36, 252, 132, 173, 68, 11, 157, 61, 98, 208, 146, 170, 174, 252, 249, 209, 106, 130, 188, 127, 204, 132, 97, 15, 217, 8, 4, 108, 221, 113, 140, 38, 202, 144, 253, 14, 207, 219, 76, 48, 119, 208, 22, 203, 224, 19, 122, 253, 172, 44, 177, 148, 98, 29, 139, 125, 108, 252, 6, 106, 211 }, new byte[] { 81, 39, 176, 205, 169, 247, 8, 59, 72, 71, 239, 237, 165, 186, 252, 149, 141, 86, 148, 177, 200, 89, 8, 81, 123, 62, 88, 181, 41, 60, 117, 238, 76, 162, 183, 170, 62, 195, 93, 58, 15, 90, 253, 88, 45, 17, 61, 255, 239, 198, 28, 128, 207, 73, 65, 209, 117, 148, 114, 34, 143, 246, 103, 64, 48, 186, 53, 201, 130, 136, 241, 36, 208, 220, 101, 41, 219, 7, 21, 222, 179, 66, 66, 146, 110, 80, 167, 246, 60, 91, 63, 99, 186, 186, 189, 200, 244, 108, 141, 21, 202, 239, 137, 201, 103, 104, 198, 119, 136, 71, 122, 118, 241, 145, 60, 1, 91, 165, 254, 60, 54, 4, 233, 227, 178, 240, 49, 201 }, "Admin", "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlaylistId",
                table: "Game",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_UserId",
                table: "MusicPlaylists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistId",
                table: "Songs",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownicy_currentGameId",
                table: "Uzytkownicy",
                column: "currentGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_MusicPlaylists_PlaylistId",
                table: "Game",
                column: "PlaylistId",
                principalTable: "MusicPlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_MusicPlaylists_PlaylistId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "MusicPlaylists");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
