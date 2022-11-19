using BSPracaInzynierska.Shared;
using Microsoft.EntityFrameworkCore;

namespace BSPracaInzynierska.Server.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<User> Uzytkownicy { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Email="user", Id=1, PasswordHash=null, PasswordSalt=null, Role="Admin", Username="user"}
                );
            modelBuilder.Entity<Song>().HasData(
                new Song { Id=1, author="dgsdfg", title="fgsfg"}
                );
        }
    }
}
