using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConnectaSummer.Domain.Users
{
    public interface IUser
    {
        Task SaveAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(User user);

        Task<User> GetByIdAsync(Guid id);

        Task<List<User>> GetAllAsync(Func<User, bool> predicate);

        Task<List<User>> GetAllAsync();

        Task<List<User>> GetByNameAsync(string name, int page, int itensPerPage);
    }
}
