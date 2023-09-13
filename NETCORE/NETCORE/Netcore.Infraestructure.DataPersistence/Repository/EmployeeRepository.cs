using Microsoft.EntityFrameworkCore;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.Constants;
using NetCore.Domain.Entities.DTO;

namespace NetCore.Infraestructure.DataPersistence.Repository
{
    public class EmployeeRepository : DBBase, IEmployeeRepository
    {
        public EmployeeRepository(DapperContext dapperContext) : base(dapperContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            var result = (await ExecuteQuery<Employee>(
                $"SELECT *" +
                $" FROM {DatabaseTables.Employee}" +
                $" WHERE [Active] = 1 ")).ToList();
            return result;

        }
        public async Task<EmployeeWeekPeriod> GetEmployeeByEmployeeAndWeekPeriod(string weekPeriodId, int employeeId)
        {
            var query = $"SELECT E.Id,E.[FirstName],E.[LastName],E.[Address],E.[Email],E.[PhoneNumber],E.[Profile],E.[IsFullTime],E.[HourRate],E.[Active],E.[InsertedDate],E.[UpdatedDate], WP.WorkedHours " +
                $"FROM {DatabaseTables.Employee} AS E " +
                $"INNER JOIN {DatabaseTables.WeekPeriod} AS WP " +
                $"ON E.Id = WP.EmployeeId AND WP.Id = '{weekPeriodId}' " +
                $"WHERE E.ID = {employeeId}";
            var result = (await ExecuteQuery<EmployeeWeekPeriod>(query)).FirstOrDefault();
            return result;
        }

        public async Task<Employee> GetEmployeeById(int Id)
        {
            var result = (await ExecuteQuery<Employee>(
                $"SELECT *" +
                $" FROM {DatabaseTables.Employee}" +
                $" WHERE [Id] = {Id}")).FirstOrDefault();
            return result;

        }

        public async Task<IEnumerable<Employee>> GetByField(string field, string value)
        {
            string Choseen = "";
            if (string.IsNullOrEmpty(value))
                return await GetAllEmployees();
            switch (field)
            {
                case "firstName":
                    Choseen = "FirstName";
                    break;
                case "lastName":
                    Choseen = "LastName";
                    break;
                case "Address":
                    Choseen = "Address";
                    break;
                case "profile":
                    Choseen = "Profile";
                    break;
                default:
                    Choseen = "Id";
                    break;
            }
            string query =
                $"SELECT *" +
                $" FROM {DatabaseTables.Employee} " +
                $" WHERE [{Choseen}] LIKE '%{value}%'";
            return (await ExecuteQuery<Employee>(query)).ToList();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            var query =
                $"UPDATE {DatabaseTables.Employee}" +
                $" SET [FirstName] = @firstName" +
                $",[LastName] = @lastName " +
                $",[Address] = @address " +
                $",[email] = @email " +
                $",[PhoneNumber] = @phoneNumber " +
                $",[Profile] = @profile  " +
                $",[IsFullTime] = @isFullTime" +
                $",[InsertedDate] = getdate()" +
                $",[UpdatedDate] = getdate()" +
                $",[HourRate] = @hourRate" +
                $",[Active] = @active" +
                $" WHERE [Id] = {employee.Id}";
            await ExecuteQuery(query,
                new
                {
                    @firstName = employee.FirstName,
                    @lastName = employee.LastName,
                    @address = employee.Address,
                    @email = employee.Email,
                    @phoneNumber = employee.PhoneNumber,
                    @profile = employee.Profile,
                    @isFullTime = employee.IsFullTime,
                    @hourRate = employee.HourRate,
                    @active = employee.Active
                });
        }
        public async Task AddEmployee(Employee employee)
        {
            try
            {


                var query = $"INSERT INTO {DatabaseTables.Employee} " +
                    $" ([FirstName]" +
                    $",[LastName]" +
                    $",[Address]" +
                    $",[email]" +
                    $",[PhoneNumber]" +
                    $",[Profile]" +
                    $",[IsFullTime]" +
                    $",[InsertedDate]" +
                    $",[UpdatedDate] " +
                    $",[HourRate]" +
                    $",[Active]) " +
                    $" VALUES" +
                    $"(@firstName" +
                    $",@lastName " +
                    $",@address " +
                    $",@email " +
                    $",@phoneNumber " +
                    $",@profile  " +
                    $",@isFullTime" +
                    $",getdate()" +
                    $",getdate()" +
                    $",@hourRate" +
                    $",@active" +
                    $")";
                await ExecuteQuery(
                    query,
                    new
                    {
                        @firstName = employee.FirstName,
                        @lastName = employee.LastName,
                        @address = employee.Address,
                        @email = employee.Email,
                        @phoneNumber = employee.PhoneNumber,
                        @profile = employee.Profile,
                        @isFullTime = employee.IsFullTime,                        
                        @hourRate = employee.HourRate,
                        @active = employee.Active
                    });
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task RemoveEmployee(int Id)
        {
            await ExecuteQuery(
                $"UPDATE {DatabaseTables.Employee}" +
                $"SET [Active] = 0 " +
                $"WHERE [Id] = {Id}");
        }
    }
}
