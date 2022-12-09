﻿// <auto-generated />
using System;
using BSPracaInzynierska.Server.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BSPracaInzynierska.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Uzytkownicy");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fa7e81a8-032d-4689-a067-7453484d6bb5"),
                            Email = "admin",
                            PasswordHash = new byte[] { 67, 11, 47, 185, 251, 46, 129, 4, 119, 116, 191, 199, 209, 250, 136, 229, 157, 213, 150, 249, 226, 98, 122, 92, 183, 158, 216, 199, 156, 98, 106, 18, 122, 70, 145, 159, 168, 69, 56, 204, 137, 89, 38, 229, 149, 107, 225, 142, 99, 213, 140, 97, 55, 103, 57, 111, 47, 172, 122, 207, 74, 159, 213, 87 },
                            PasswordSalt = new byte[] { 15, 212, 100, 170, 23, 255, 187, 140, 99, 213, 39, 34, 237, 211, 230, 164, 51, 27, 0, 47, 90, 241, 173, 146, 142, 88, 156, 49, 196, 44, 150, 212, 48, 2, 153, 31, 240, 235, 169, 44, 254, 164, 38, 21, 181, 92, 79, 145, 46, 179, 4, 15, 106, 222, 232, 162, 222, 23, 89, 25, 133, 205, 120, 33, 93, 233, 226, 157, 107, 12, 84, 17, 205, 124, 22, 143, 179, 145, 107, 126, 66, 5, 177, 140, 183, 48, 2, 159, 56, 79, 210, 144, 66, 59, 13, 19, 129, 83, 106, 234, 199, 23, 29, 9, 35, 226, 142, 209, 61, 216, 103, 112, 91, 204, 31, 200, 250, 132, 109, 107, 229, 209, 64, 245, 106, 139, 160, 189 },
                            Role = "Admin",
                            Username = "admin"
                        });
                });

            modelBuilder.Entity("BSPracaInzynierska.Shared.MultiGame", b =>
                {
                    b.HasOne("BSPracaInzynierska.Shared.MusicPlaylist", "Playlist")
                        .WithMany("CurrentGames")
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

            modelBuilder.Entity("BSPracaInzynierska.Shared.MusicPlaylist", b =>
                {
                    b.Navigation("CurrentGames");

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
