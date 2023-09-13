using NetCore.Domain.Abstractions.Repository;
using NetCore.Infraestructure.DataPersistence.Repository;

namespace NetCore.Infraestructure.DataPersistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private DapperContext _dapperContext;

        public UnitOfWork(DapperContext dapperContext)
        {
            _dapperContext = dapperContext; 
            EmployeeRepository = new EmployeeRepository(_dapperContext);
            UserRepository = new UserRepository(_dapperContext);
        }


        public IEmployeeRepository EmployeeRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
    }
}
