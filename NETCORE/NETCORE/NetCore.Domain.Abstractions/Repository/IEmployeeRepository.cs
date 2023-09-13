
using NetCore.Domain.Entities;

namespace NetCore.Domain.Abstractions.Repository
{
    public  interface IEmployeeRepository 
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<IEnumerable<Employee>> GetByField(string field, string value);
        Task RemoveEmployee(int Id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task<Employee> GetEmployeeById(int Id);
        Task<EmployeeWeekPeriod> GetEmployeeByEmployeeAndWeekPeriod(string weekPeriodId, int employeeId);

    }
}
