using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class Initial2 : Migration
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
                    favourites = table.Column<long>(type: "bigint", nullable: false),
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
                name: "LeaderBoard",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PlaylistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    playerTime = table.Column<double>(type: "float", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderBoard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderBoard_MusicPlaylists_PlaylistId",
                        column: x => x.PlaylistId,
                        principalTable: "MusicPlaylists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaderBoard_Uzytkownicy_UserId",
                        column: x => x.UserId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusicPlaylistUser",
                columns: table => new
                {
                    FavouritePlaylistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersFavouritesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylistUser", x => new { x.FavouritePlaylistsId, x.UsersFavouritesId });
                    table.ForeignKey(
                        name: "FK_MusicPlaylistUser_MusicPlaylists_FavouritePlaylistsId",
                        column: x => x.FavouritePlaylistsId,
                        principalTable: "MusicPlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicPlaylistUser_Uzytkownicy_UsersFavouritesId",
                        column: x => x.UsersFavouritesId,
                        principalTable: "Uzytkownicy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                values: new object[] { new Guid("533c819e-d18c-4a16-a5f4-32a9b5fcaefc"), "admin", new byte[] { 58, 185, 106, 223, 89, 59, 250, 118, 25, 112, 50, 18, 167, 248, 255, 168, 198, 162, 176, 211, 240, 184, 76, 207, 196, 218, 131, 153, 152, 19, 164, 51, 222, 196, 216, 170, 210, 7, 47, 185, 42, 103, 106, 143, 157, 188, 144, 221, 131, 12, 193, 160, 90, 91, 6, 80, 174, 134, 9, 244, 125, 96, 238, 177 }, new byte[] { 196, 253, 84, 14, 201, 247, 85, 152, 177, 207, 195, 33, 23, 33, 8, 232, 55, 136, 248, 240, 1, 63, 172, 81, 214, 229, 211, 216, 112, 220, 154, 76, 226, 206, 130, 46, 158, 187, 217, 28, 112, 219, 52, 165, 26, 13, 48, 148, 119, 172, 245, 138, 50, 220, 88, 205, 138, 129, 122, 194, 178, 205, 48, 187, 218, 37, 172, 163, 224, 121, 92, 91, 29, 207, 254, 107, 143, 252, 250, 208, 250, 249, 245, 114, 41, 108, 213, 72, 90, 71, 106, 121, 216, 168, 106, 190, 3, 35, 69, 29, 144, 54, 136, 86, 251, 164, 32, 211, 63, 239, 178, 213, 96, 254, 162, 243, 231, 219, 18, 193, 38, 174, 172, 76, 161, 77, 247, 97 }, "Admin", "admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Game_PlaylistId",
                table: "Game",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderBoard_PlaylistId",
                table: "LeaderBoard",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderBoard_UserId",
                table: "LeaderBoard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_UserId",
                table: "MusicPlaylists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistUser_UsersFavouritesId",
                table: "MusicPlaylistUser",
                column: "UsersFavouritesId");

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
                name: "LeaderBoard");

            migrationBuilder.DropTable(
                name: "MusicPlaylistUser");

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
