using NetCore.Domain.Entities;
using NetCore.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Abstractions.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task RemoveUser(int Id);
        Task AddUser(UserDTO user);
        Task UpdateUser(UserDTO user);
        Task<bool> ValidateSession(string UserName, string password);
    }
}
