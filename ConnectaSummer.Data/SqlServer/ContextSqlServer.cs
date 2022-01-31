using ConnectaSummer.Data.Map;
using ConnectaSummer.Domain.AccountHolders;
using ConnectaSummer.Domain.Accounts;
using ConnectaSummer.Domain.Extracts;
using ConnectaSummer.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ConnectaSummer.Data.SqlServer
{
    public class ContextSqlServer: DbContext
    {
        public ContextSqlServer(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AccountHolder> AccountHolders { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Extract> Extracts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AccountHolderMap().Configure(modelBuilder.Entity<AccountHolder>());

            base.OnModelCreating(modelBuilder);             
        }
    }
}