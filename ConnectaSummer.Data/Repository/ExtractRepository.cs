using ConnectaSummer.Domain.Extracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectaSummer.Data.Repository
{
    public class ExtractRepository : IExtractRepository
    {
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

        public Task SaveAsync(Extract extract)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Extract extract)
        {
            throw new NotImplementedException();
        }
    }
}