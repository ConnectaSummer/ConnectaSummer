using ConnectaSummer.Data.SqlServer;
using ConnectaSummer.Domain.Extracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectaSummer.Data.Repository
{
    public class ExtractRepository : IExtractRepository
    {
        private readonly ContextSqlServer _context;

        public ExtractRepository(ContextSqlServer context)
        {
            _context = context;
        }
        public Task<List<Extract>> GetAllAsync(Func<Extract, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Extract>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Extract> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Extract>> GetByNameAsync(string name, int page, int itensPerPage)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Extract extract)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(Extract extract)
        {
            await _context.Extracts.AddAsync(extract);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(Extract extract)
        {
            throw new NotImplementedException();
        }
    }
}