using ConnectaSummer.Data.SqlServer;
using ConnectaSummer.Domain.AccountHolders;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectaSummer.Data.Repository
{
    public class AccountHolderRepository : IAccountHolderRepository
    {
        private readonly ContextSqlServer _context;

        public AccountHolderRepository(ContextSqlServer context)
        {
            _context = context;
        }

        public Task<AccountHolder> FindByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountHolder>> GetAllAsync(Func<AccountHolder, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountHolder>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccountHolder> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccountHolder>> GetByNameAsync(string name, int page, int itensPerPage)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(AccountHolder accountHolder)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(AccountHolder accountHolder)
        {
            await _context.AccountHolders.AddAsync(accountHolder);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(AccountHolder accountHolder)
        {
            throw new NotImplementedException();
        }
    }
}