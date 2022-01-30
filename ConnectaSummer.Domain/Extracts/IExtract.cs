﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.Extracts
{
    public interface IExtract
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
