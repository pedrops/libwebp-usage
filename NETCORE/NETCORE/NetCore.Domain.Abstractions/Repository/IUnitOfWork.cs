using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Abstractions.Repository
{
    public interface IUnitOfWork
    {
        IEmployeeRepository EmployeeRepository { get; }
        IUserRepository UserRepository { get; }
    }
}
