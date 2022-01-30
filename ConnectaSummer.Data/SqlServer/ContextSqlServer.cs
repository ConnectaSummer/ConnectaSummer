using ConnectaSummer.Domain.AccountHolders;
using ConnectaSummer.Domain.Accounts;
using ConnectaSummer.Domain.Extracts;
using ConnectaSummer.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ConnectaSummer.Data.SqlServer
{
    public class ContextSqlServer: System.Data.Entity.DbContext
    {
        public ContextSqlServer(DbContextOptions options) : base()//(options)
        {

        }

        public Microsoft.EntityFrameworkCore.DbSet<AccountHolder> AccountHolders { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Account> Accounts { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<Extract> Extracts { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<User> Users { get; set; }

    }
}
