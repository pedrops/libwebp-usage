using NetCore.Domain.Entities.DTO;

namespace NetCore.Domain.Abstractions.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetAll();
        Task<IEnumerable<EmployeeDTO>> GeByField(string field, string value);
        void AddEmployee(EmployeeAddDTO employeeDTO);
        void UpdateEmployee(EmployeeUpdateDTO employee);
        void RemoveEmployee(int employeeId);
        Task<EmployeeWeekPeriodDTO> GetEmployeeByEmployeeAndWeekPeriod(string weekPeriodId, int employeeId);
        Task<EmployeeDTO> GetEmployeeById(int Id);
    }
}
