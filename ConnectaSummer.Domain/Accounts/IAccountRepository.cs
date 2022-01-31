using System;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.Accounts
{
    public interface IAccountRepository
    {
        Task<Account> GetByAgencyAndAccountAsync(string agency, string accountNumber);
        Task Update(Account account);
    }
}