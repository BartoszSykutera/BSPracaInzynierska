using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    public partial class SD : Migration
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
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { new Guid("c7d5f84c-eb0c-40de-aa92-17d7685e7845"), "admin", new byte[] { 198, 101, 72, 154, 221, 6, 201, 13, 214, 29, 84, 126, 64, 86, 150, 91, 240, 32, 145, 33, 31, 65, 244, 47, 190, 166, 109, 197, 6, 5, 223, 76, 225, 84, 58, 1, 111, 244, 56, 101, 240, 222, 215, 179, 114, 47, 61, 74, 121, 119, 227, 155, 150, 117, 171, 221, 229, 158, 168, 220, 102, 245, 9, 56 }, new byte[] { 121, 201, 107, 114, 53, 238, 226, 163, 54, 53, 131, 214, 179, 39, 196, 176, 151, 21, 73, 173, 104, 122, 218, 17, 62, 233, 67, 97, 14, 19, 137, 190, 205, 102, 181, 44, 227, 34, 8, 203, 43, 205, 88, 51, 210, 184, 229, 42, 28, 254, 231, 15, 170, 145, 181, 197, 227, 165, 214, 154, 246, 179, 215, 52, 93, 167, 133, 10, 177, 68, 180, 125, 67, 169, 213, 29, 158, 34, 242, 183, 86, 127, 50, 90, 2, 218, 53, 25, 166, 238, 179, 72, 10, 120, 147, 163, 194, 211, 5, 27, 27, 121, 89, 242, 199, 236, 163, 160, 116, 143, 206, 41, 144, 45, 168, 243, 148, 65, 123, 193, 253, 233, 135, 229, 212, 169, 87, 71 }, "Admin", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylists_UserId",
                table: "MusicPlaylists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Songs_PlaylistId",
                table: "Songs",
                column: "PlaylistId");
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
