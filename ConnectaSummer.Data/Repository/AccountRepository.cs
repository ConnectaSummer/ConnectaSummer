using ConnectaSummer.Data.SqlServer;
using ConnectaSummer.Domain.Accounts;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectaSummer.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ContextSqlServer _context;

        public AccountRepository(ContextSqlServer context)
        {
            _context = context;
        }


        public async Task<Account> GetByAgencyAndAccountAsync(string agency, string accountNumber)
        {
            return _context.Accounts.Where(x => x.Agency == agency && x.NumberAccount == accountNumber).FirstOrDefault();
        }

        public async Task Update(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }
    }
}