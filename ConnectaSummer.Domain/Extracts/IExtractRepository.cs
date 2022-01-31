using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.Extracts
{
    public interface IExtractRepository
    {
        Task SaveAsync(Extract extract);
        Task UpdateAsync(Extract extract);
        Task RemoveAsync(Extract extract);

        Task<Extract> GetByIdAsync(Guid id);

        Task<List<Extract>> GetAllAsync(Func<Extract, bool> predicate);

        Task<List<Extract>> GetAllAsync();

        Task<List<Extract>> GetByNameAsync(string name, int page, int itensPerPage);
    }
}