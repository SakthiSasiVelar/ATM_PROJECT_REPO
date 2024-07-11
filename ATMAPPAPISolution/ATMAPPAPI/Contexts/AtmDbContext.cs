using ATMAPPAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ATMAPPAPI.Contexts
{
    public class AtmDbContext:DbContext
    {
        public AtmDbContext(DbContextOptions<AtmDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<CardInfo> CardInfos { get; set; }
        public DbSet<UserCredentials> UserCredentials { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
