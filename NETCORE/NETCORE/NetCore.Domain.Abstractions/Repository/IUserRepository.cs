using NetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Abstractions.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task RemoveUser(int Id);
        Task AddUser(User user);
        Task UpdateUser(User user);
        Task<string> GetPasswordByUserName(string userName);
    }
}
