using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Entities.DTO;
using NetCore.Domain.Entities;

namespace NetCore.Services.BusinessLogic
{
    public class EmployeeServiceUoW
    {
        private IUnitOfWork _unitOfWork;
        public EmployeeServiceUoW(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            _unitOfWork.EmployeeRepository.AddEmployee(newEmployee);
        }

        public async Task<IEnumerable<EmployeeDTO>> GeByField(string field, string value)
        {
            return (await _unitOfWork.EmployeeRepository.GetByField(field, value))
                .Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Profile = x.Profile,
                    IsFullTime = x.IsFullTime,
                    InsertedDate = x.InsertedDate,
                    UpdatedDate = x.UpdatedDate,
                    HourRate = x.HourRate,
                    Active = x.Active
                });
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return (await _unitOfWork.EmployeeRepository.GetAllEmployees())
                .Select(x => new EmployeeDTO()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Address = x.Address,
                    Email = x.Email,
                    PhoneNumber = x.PhoneNumber,
                    Profile = x.Profile,
                    IsFullTime = x.IsFullTime,
                    InsertedDate = x.InsertedDate,
                    UpdatedDate = x.UpdatedDate,
                    HourRate = x.HourRate,
                    Active = x.Active
                });
        }

        public async Task<EmployeeDTO> GetEmployeeById(int Id)
        {
            var result = await _unitOfWork.EmployeeRepository.GetEmployeeById(Id);
            return (
                new EmployeeDTO()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Address = result.Address,
                    Email = result.Email,
                    PhoneNumber = result.PhoneNumber,
                    Profile = result.Profile,
                    IsFullTime = result.IsFullTime,
                    InsertedDate = result.InsertedDate,
                    UpdatedDate = result.UpdatedDate,
                    HourRate = result.HourRate,
                    Active = result.Active
                });
        }
        public async Task<EmployeeDTO> GetEmployeeByWeekPeriodId(string weekPeriodId, int employeeId)
        {
            var result = await _unitOfWork.EmployeeRepository.GetEmployeeByEmployeeAndWeekPeriod(weekPeriodId, employeeId);
            if (result == null)
                return new EmployeeDTO();
            return (
                new EmployeeDTO()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Address = result.Address,
                    Email = result.Email,
                    PhoneNumber = result.PhoneNumber,
                    Profile = result.Profile,
                    IsFullTime = result.IsFullTime,
                    InsertedDate = result.InsertedDate,
                    UpdatedDate = result.UpdatedDate,
                    HourRate = result.HourRate,
                    Active = result.Active
                });
        }

        public void RemoveEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            _unitOfWork.EmployeeRepository.RemoveEmployee(newEmployee.Id);
        }

        public void UpdateEmployee(EmployeeDTO employeeDTO)
        {
            var newEmployee = new Employee(employeeDTO);
            _unitOfWork.EmployeeRepository.UpdateEmployee(newEmployee);
        }
    }
}