using BSPracaInzynierska.Shared;
using Microsoft.EntityFrameworkCore;

namespace BSPracaInzynierska.Server.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
