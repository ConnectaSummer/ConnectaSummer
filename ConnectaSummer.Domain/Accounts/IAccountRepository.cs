using System;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.Accounts
{
    public interface IAccountRepository
    {
        Task<Account> FindByIdAsync(Guid Id);
    }
}