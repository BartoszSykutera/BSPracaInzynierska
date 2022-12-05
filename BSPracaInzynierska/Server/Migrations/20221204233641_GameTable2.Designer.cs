﻿// <auto-generated />
using System;
using BSPracaInzynierska.Server.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221204233641_GameTable2")]
    partial class GameTable2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BSPracaInzynierska.Shared.MultiGame", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GameCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfTracks")
                        .HasColumnType("int");

                    b.Property<Guid>("PlaylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserHost")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("gameTime")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MusicPlaylist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfTracks")
                        .HasColumnType("int");

                    b.Property<string>("PlaylistName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MusicPlaylists");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.Song", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PlaylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("SongDuration")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YTChanelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YTVideoTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YTVidoeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("MultiGameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MultiGameId");

                    b.ToTable("Uzytkownicy");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9bbeb874-b4ae-408c-ab94-1a45e34c1dbd"),
                            Email = "admin",
                            PasswordHash = new byte[] { 131, 31, 37, 196, 22, 92, 173, 219, 22, 168, 217, 217, 194, 193, 115, 197, 8, 182, 60, 104, 105, 136, 148, 124, 36, 175, 30, 227, 15, 221, 8, 85, 3, 148, 137, 93, 255, 166, 120, 168, 28, 195, 162, 228, 215, 26, 128, 219, 104, 79, 157, 235, 114, 86, 109, 133, 133, 170, 78, 188, 145, 253, 106, 223 },
                            PasswordSalt = new byte[] { 23, 71, 128, 140, 157, 51, 246, 63, 120, 20, 194, 99, 172, 1, 131, 7, 159, 41, 151, 129, 108, 153, 122, 70, 173, 36, 163, 85, 47, 248, 107, 7, 152, 225, 165, 229, 243, 239, 156, 251, 176, 172, 122, 106, 53, 153, 8, 217, 181, 248, 208, 4, 220, 169, 16, 72, 219, 140, 13, 174, 233, 217, 113, 81, 75, 254, 49, 41, 51, 252, 150, 73, 15, 252, 76, 207, 56, 94, 16, 244, 48, 252, 40, 116, 64, 158, 227, 133, 67, 246, 93, 219, 147, 119, 116, 196, 173, 121, 57, 157, 102, 154, 160, 14, 144, 228, 232, 100, 178, 166, 2, 25, 179, 60, 97, 58, 53, 136, 214, 41, 154, 60, 82, 104, 24, 77, 169, 70 },
                            Role = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MultiGame", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.MusicPlaylist", "Playlist")
                        .WithMany()
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MusicPlaylist", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.User", "Creator")
                        .WithMany("MusicPlaylists")
                        .HasForeignKey("UserId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.Song", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.MusicPlaylist", "Playlist")
                        .WithMany("Songs")
                        .HasForeignKey("PlaylistId");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.User", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.MultiGame", null)
                        .WithMany("Players")
                        .HasForeignKey("MultiGameId");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MultiGame", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MusicPlaylist", b =>
                {
                    b.Navigation("Songs");
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.User", b =>
                {
                    b.Navigation("MusicPlaylists");
                });
#pragma warning restore 612, 618
        }
    }
}
