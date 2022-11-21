using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class ChangeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.Id);
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
                    YTChanelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicPlaylistId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Songs_MusicPlaylists_MusicPlaylistId",
                        column: x => x.MusicPlaylistId,
                        principalTable: "MusicPlaylists",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Uzytkownicy",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("b8efb714-9813-49d5-a9c7-fc0b129c2f47"), "admin", new byte[] { 120, 90, 211, 244, 76, 217, 46, 12, 153, 51, 116, 143, 74, 87, 146, 25, 221, 26, 8, 74, 99, 62, 25, 171, 166, 243, 117, 61, 64, 103, 134, 161, 86, 239, 131, 120, 171, 124, 203, 60, 111, 54, 225, 252, 8, 241, 180, 156, 255, 28, 113, 203, 146, 60, 71, 242, 164, 172, 51, 78, 130, 235, 161, 217 }, new byte[] { 180, 73, 148, 150, 71, 126, 218, 75, 158, 33, 124, 102, 103, 130, 21, 117, 141, 9, 37, 96, 88, 55, 55, 86, 208, 15, 0, 252, 222, 141, 12, 53, 207, 252, 17, 73, 242, 109, 168, 196, 194, 255, 63, 174, 220, 117, 83, 60, 175, 234, 136, 93, 18, 102, 239, 65, 215, 154, 245, 72, 3, 108, 20, 213, 150, 92, 123, 195, 54, 97, 83, 95, 36, 129, 80, 155, 71, 221, 185, 57, 77, 7, 174, 53, 186, 251, 32, 200, 162, 224, 37, 1, 152, 2, 191, 14, 67, 135, 39, 73, 57, 241, 53, 194, 156, 219, 123, 240, 247, 103, 150, 75, 243, 168, 98, 202, 48, 117, 37, 53, 22, 56, 80, 79, 232, 183, 213, 57 }, "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_UserId",
                table: "MusicPlaylists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_MusicPlaylistId",
                table: "Songs",
                column: "MusicPlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Songs");

            migrationBuilder.DropTable(
                name: "MusicPlaylists");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");
        }
    }
}
