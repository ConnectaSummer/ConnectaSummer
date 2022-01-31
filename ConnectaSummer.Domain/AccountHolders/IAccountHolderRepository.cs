using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.AccountHolders
{
    public interface IAccountHolderRepository
    {
        Task<AccountHolder> FindByIdAsync(Guid Id);

        Task SaveAsync(AccountHolder accountHolder);

        Task UpdateAsync(AccountHolder accountHolder);
        Task RemoveAsync(AccountHolder accountHolder);

        Task<AccountHolder> GetByIdAsync(Guid id);

        Task<List<AccountHolder>> GetAllAsync(Func<AccountHolder, bool> predicate);

        Task<List<AccountHolder>> GetAllAsync();

        Task<List<AccountHolder>> GetByNameAsync(string name, int page, int itensPerPage);
    }
}