using Moq;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Entities;
using Xunit;

namespace NetCore.Services.BusinessLogic
{
    public class EmployeeServiceTDD
    {

        private EmployeeService _employeeServiceWrong;
        private Mock<IEmployeeRepository> _mockEmployeeRepositoryWrong;

        private EmployeeService _employeeServiceGood;
        private Mock<IEmployeeRepository> _mockEmployeeRepositoryGood;

        private EmployeeService _employeeServiceNew;
        private Mock<IEmployeeRepository> _mockEmployeeRepositoryNew;

        //public IConfigurationRoot CreateConfig()
        //{            
        //    return
        //        new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddJsonFile("appsettings.json")
        //        .Build();
        //}







        public EmployeeServiceTDD()
        {

            _mockEmployeeRepositoryWrong = new Mock<IEmployeeRepository>();
            _mockEmployeeRepositoryWrong.Setup(rep => rep.GetEmployeeByEmployeeAndWeekPeriod(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(
                new EmployeeWeekPeriod()
                {
                    Id = 1,
                    FirstName = "Pedro",
                    LastName = "",
                    Address = "44 E. West Street Ashland, OH 44805",
                    PhoneNumber = "",
                    IsFullTime = true,
                    Profile = "Admin",
                    Email = "pmonzon@gmail.com",
                    Active = false,
                    HourRate = 20,
                    WorkedHours = 30
                });
            
            _mockEmployeeRepositoryWrong.Setup(rep => rep.GetEmployeeById(It.IsAny<int>()))
               .ReturnsAsync(
               new Employee()
               {
                   Id = 1,
                   FirstName = "Pedro",
                   LastName = "",
                   Address = "44 E. West Street Ashland, OH 44805",
                   PhoneNumber = "",
                   IsFullTime = true,
                   Profile = "Admin",
                   Email = "pmonzon@gmail.com",
                   Active = false,
                   HourRate = 20,
               });
            

            
            _mockEmployeeRepositoryWrong.Setup(rep => rep.GetAllEmployees())
                .ReturnsAsync(
                new List<Employee>()
                {
                    new Employee
                    {
                        Id = 1,
                        FirstName = "Pedro",
                        LastName = "",
                        Address = "44 E. West Street Ashland, OH 44805",
                        PhoneNumber = "",
                        IsFullTime = true,
                        Profile = "Admin",
                        Email = "pmonzon@gmail.com",
                        Active = false,
                        HourRate = 20,
                    },
                    new Employee
                    {
                        Id = 2,
                        FirstName = "Juan",
                        LastName = "Monzon",
                        Address = "44 E. West Street Ashland, OH 44805",
                        PhoneNumber = "",
                        IsFullTime = true,
                        Profile = "Manager",
                        Email = "jmonzon@entropyzero.com",
                        Active = false,
                        HourRate = 30,
                    } });

            _employeeServiceWrong = new EmployeeService(_mockEmployeeRepositoryWrong.Object);

            
            _mockEmployeeRepositoryGood = new Mock<IEmployeeRepository>();
            _mockEmployeeRepositoryGood.Setup(rep => rep.GetEmployeeByEmployeeAndWeekPeriod(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(
                new EmployeeWeekPeriod()
                {
                    Id = 1,
                    FirstName = "Pedro",
                    LastName = "Monzon",
                    Address = "44 E. West Street Ashland, OH 44805",
                    PhoneNumber = "8002472020",
                    IsFullTime = true,
                    Profile = "Admin",
                    Email = "pmonzon@gmail.com",
                    Active = false,
                    HourRate = 20,
                    WorkedHours = 50
                });

            _mockEmployeeRepositoryGood.Setup(rep => rep.GetEmployeeById(It.IsAny<int>()))
               .ReturnsAsync(
               new Employee()
               {
                   Id = 1,
                   FirstName = "Pedro",
                   LastName = "Monzon",
                   Address = "44 E. West Street Ashland, OH 44805",
                   PhoneNumber = "456456456",
                   IsFullTime = true,
                   Profile = "Admin",
                   Email = "pmonzon@entropyzero.com",
                   Active = false,
                   HourRate = 50,
               });

            _employeeServiceGood = new EmployeeService(_mockEmployeeRepositoryGood.Object);

            _mockEmployeeRepositoryNew = new Mock<IEmployeeRepository>();
            _mockEmployeeRepositoryNew.Setup(rep => rep.GetEmployeeByEmployeeAndWeekPeriod(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(
                new EmployeeWeekPeriod()
                {
                    Id = 1,
                    FirstName = "Pedro",
                    LastName = "Monzon",
                    Address = "44 E. West Street Ashland, OH 44805",
                    PhoneNumber = "8002472020",
                    IsFullTime = true,
                    Profile = "Admin",
                    Email = "pmonzon@gmail.com",
                    Active = false,
                    HourRate = 20,
                    WorkedHours = 0
                });

            _employeeServiceNew = new EmployeeService(_mockEmployeeRepositoryNew.Object);

            ////var _config = CreateConfig();

            ////var dapperContext =
            // //   new DapperContext(_config);

            ////_employeeRepository =
            ////    new EmployeeRepository(dapperContext);

            //_employeeService = new EmployeeService(_mockEmployeeRepository.Object);

        }


        [Fact]
        public async Task VerifyEmployeeDomainSingleRecord_WrongDomain_Success()
        {
            var result = await _employeeServiceWrong.GetEmployeeById(1515);
            Assert.Equal("no email", result.Email);
        }

        [Fact]
        public async Task VerifyEmployeeDomainSingleRecord_ProperDomain_Success()
        {
            var result = await _employeeServiceGood.GetEmployeeById(1515);
            Assert.Contains("entropyzero.com", result.Email);
        }

        [Fact]
        public async Task VerifyEmployeeDomainList_ProperDomains_Success()
        {
            var result = await _employeeServiceWrong.GetAll();
            Assert.True(result.Where(x => (x.Email == "no email")).Count() == 1);
        }

        [Fact]
        public async Task VerifyEmployeeLastNameSingleRecord_WrongLastName_Success()
        {
            var result = await _employeeServiceWrong.GetEmployeeById(1515);
            Assert.Equal("no lastname", result.LastName);
        }

        [Fact]
        public async Task VerifyEmployeeLastNameSingleRecord_ProperLastName_Success()
        {
            var result = await _employeeServiceGood.GetEmployeeById(1515);
            Assert.NotEqual("no lastname", result.LastName);
        }

        [Fact]
        public async Task VerifyEmployeeDomainList_BadAndGoodLastName_Success()
        {
            var result = await _employeeServiceWrong.GetAll();
            Assert.True(result.Where(x => (x.LastName == "no lastname")).Count() == 1);
        }




        [Fact]
        public async Task VerifyEmployeePhoneNumberSingleRecord_WrongPhoneNumber_Success()
        {
            var result = await _employeeServiceWrong.GetEmployeeById(1515);
            Assert.Equal("8002472020", result.PhoneNumber);
        }

        [Fact]
        public async Task VerifyEmployeePhoneNumberSingleRecord_ProperPhoneNumber_Success()
        {
            var result = await _employeeServiceGood.GetEmployeeById(1515);
            Assert.NotEqual("8002472020", result.PhoneNumber);
        }

        [Fact]
        public async Task VerifyEmployeePhoneNumbersList_WrongPhoneNumbers_Success()
        {
            var result = await _employeeServiceWrong.GetAll();
            Assert.True(result.Where(x => (x.PhoneNumber == "8002472020")).Count() == 2);
        }


        [Fact]
        public async Task VerifyEmployeePaymentIsZero_ValidEmployeeRecord_Success()
        {
            var result = await _employeeServiceNew.GetEmployeeByEmployeeAndWeekPeriod("2023-7", 1515);
            Assert.Equal(0, result.Bonus);
            Assert.Equal(0, result.WeekPayment);
            Assert.Equal(0, result.WeekTotalPayment);
            Assert.Equal(0, result.WorkedHours);
        }

       
        [Fact]
        public async Task VerifyEmployeeBonus_ValidEmployeeRecord_NoBonus()
        {
            var result = await _employeeServiceWrong.GetEmployeeByEmployeeAndWeekPeriod("2023-7", 1515);
            Assert.Equal(0, result.Bonus);
        }

        [Fact]
        public async Task VerifyEmployeeBonus_ValidEmployeeRecord_Bonus()
        {
            var result = await _employeeServiceGood.GetEmployeeByEmployeeAndWeekPeriod("2023-7", 1515);
            Assert.NotEqual(0, result.Bonus);
        }

        [Fact]
        public async Task VerifyPayment_ValidEmployeeRecordWithBonus_WeekTotalPaymentIsGreaterThanRegularPayment()
        {
            var result = await _employeeServiceGood.GetEmployeeByEmployeeAndWeekPeriod("2023-8", 1616);
            Assert.NotEqual(0, result.Bonus);
            Assert.True(result.WeekTotalPayment > result.WeekPayment);
        }

        [Fact]
        public async Task VerifyPayment_ValidEmployeeRecordWithNoBonus_WeekTotalPaymentIsEqualThanRegularPayment()
        {
            var result = await _employeeServiceWrong.GetEmployeeByEmployeeAndWeekPeriod("2023-8", 1616);
            Assert.Equal(0, result.Bonus);
            Assert.Equal(result.WeekTotalPayment, result.WeekPayment);
        }

    }
}

