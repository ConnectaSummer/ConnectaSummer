using ConnectaSummer.Domain.Accounts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectaSummer.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public Task<Account> FindByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetAllAsync(Func<Account, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Account>> GetByNameAsync(string Agency, string NumberAccount)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Account account)
        {
            throw new NotImplementedException();
        }
    }
}