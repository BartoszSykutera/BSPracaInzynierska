using BSPracaInzynierska.Shared;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace BSPracaInzynierska.Server.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Uzytkownicy { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<MusicPlaylist> MusicPlaylists { get; set; }
        public DbSet<MultiGame> Game { get; set; }
        public DbSet<LeaderBoard> LeaderBoard { get; set; }
        //public DbSet<GameTypeOne> GameTypeOne { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreatePasswordHash("admin", out byte[] hash, out byte[] salt);
            modelBuilder.Entity<User>().
                HasMany<MusicPlaylist>(u => u.FavouritePlaylists).
                WithMany(p => p.UsersFavourites);
            modelBuilder.Entity<User>().
                HasMany<MusicPlaylist>(u => u.MusicPlaylists).
                WithOne(p => p.Creator);
            modelBuilder.Entity<User>().HasData(
                new User { Email="admin", PasswordHash= hash, PasswordSalt= salt, Role="Admin", Username="admin"}
                );
        }

        private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
        {
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
