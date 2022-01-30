using ConnectaSummer.Data.SqlServer;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.UnityOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextSqlServer _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(ContextSqlServer context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = (IDbContextTransaction)_context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
