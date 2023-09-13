using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.Constants;
using NetCore.Domain.Entities.DTO;

namespace Netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _emloyeeService;
        public EmployeeController(IEmployeeService emloyeeService)
        {
            _emloyeeService = emloyeeService;
        }

        [HttpGet]
        [Route("Search")]
        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesByField(string field, string value)
        {
            return await _emloyeeService.GeByField(field, value);
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDTO>> GetAllEmployees()
        {
            return await _emloyeeService.GetAll();
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<EmployeeDTO> GetEmployeeById(int Id)
        {
            return await _emloyeeService.GetEmployeeById(Id);
        }

        [HttpGet]
        [Route("GetEmployeeByEmployeeAndWeekPeriod")]
        public async Task<EmployeeWeekPeriodDTO> GetEmployeeByEmployeeAndWeekPeriod(string weekPeriodId, int employeeId)
        {
            return await _emloyeeService.GetEmployeeByEmployeeAndWeekPeriod(weekPeriodId, employeeId);
        }

        [HttpPost]
        public void AddEmployee(EmployeeAddDTO employee)
        {
             _emloyeeService.AddEmployee(employee);
        }

        [HttpPut]
        public void UpdateEmployee(EmployeeUpdateDTO employee)
        {

            _emloyeeService.UpdateEmployee(employee);
        }

        [HttpDelete]
        public void RemoveEmployee(int employeeId)
        {

            _emloyeeService.RemoveEmployee(employeeId);
        }
    }

        
}
