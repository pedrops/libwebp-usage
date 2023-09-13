using Microsoft.AspNetCore.Mvc;
using Moq;
using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.DTO;
using Xunit;

namespace Netcore.Controllers
{
    public class EmployeeControllerTDD
    {
        private Mock<IEmployeeService> _mockServiceGood;
        private Mock<IEmployeeService> _mockServiceWrong;
        private Mock<IEmployeeService> _mockServiceEmpty;
        private EmployeeController _controllerGood;
        private EmployeeController _controllerWrong;
        private EmployeeController _controllerEmpty;
        public EmployeeControllerTDD()
        {
            _mockServiceGood = new Mock<IEmployeeService>();
            _mockServiceGood.Setup(serv => serv.GetEmployeeById(It.IsAny<int>()))
            .ReturnsAsync(
                new EmployeeDTO()
                {
                    Id = 1,
                    FirstName = "Pedro",
                    LastName = "Monzon",
                    Address = "44 E. West Street Ashland, OH 44805",
                    PhoneNumber = "3216632325",
                    IsFullTime = true,
                    Profile = "Admin",
                    Email = "pmonzon@entropyzero.com",
                    Active = true,
                    Bonus = 100,
                    HourRate = 20,
                    WorkingHours = 45,
                    WeekPayment = 900,
                    WeekPaymentTotal = 1000,
                    InsertedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
            _controllerGood = new EmployeeController(_mockServiceGood.Object);


            _mockServiceWrong = new Mock<IEmployeeService>();
            _mockServiceWrong.Setup(serv => serv.GetEmployeeById(It.IsAny<int>()))
            .ReturnsAsync(
                new EmployeeDTO()
                {
                    Id = 1,
                    FirstName = "Pedro",
                    LastName = "no lastname",
                    Address = "44 E. West Street Ashland, OH 44805",
                    PhoneNumber = "8002472020",
                    IsFullTime = true,
                    Profile = "Admin",
                    Email = "no email",
                    Active = true,
                    Bonus = 0,
                    HourRate = 20,
                    WorkingHours = 0,
                    WeekPayment = 0,
                    WeekPaymentTotal = 0,
                    InsertedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now
                });
            _controllerWrong = new EmployeeController(_mockServiceWrong.Object);


            _mockServiceEmpty = new Mock<IEmployeeService>();
            _mockServiceEmpty.Setup(serv => serv.GetAll())
            .ReturnsAsync(
                new List<EmployeeDTO>()
                {
                });
            _controllerEmpty = new EmployeeController(_mockServiceEmpty.Object);


        }


        [Fact]
        public async Task VerifyEmployeeDomainSingleRecord_GoodDomain_Success()
        {
            var result = await _controllerGood.GetEmployeeById(1);
            Assert.Contains("entropyzero.com", result.Email);
        }

        [Fact]
        public async Task VerifyEmployeeDomainSingleRecord_WrongDomain_Success()
        {
            var result = await _controllerWrong.GetEmployeeById(1);
            Assert.Equal("no email", result.Email);
        }

        [Fact]
        public async Task VerifyEmployeeLastNameSingleRecord_GoodLastName_Success()
        {
            var result = await _controllerGood.GetEmployeeById(1);
            Assert.True(!string.IsNullOrEmpty(result.LastName));
        }

        [Fact]
        public async Task VerifyEmployeeLastNameSingleRecord_WrongLastName_Success()
        {
            var result = await _controllerWrong.GetEmployeeById(1);
            Assert.Equal("no lastname", result.LastName);
        }

        [Fact]
        public async Task VerifyEmployeePhoneNumberSingleRecord_GoodPhoneNumber_Success()
        {
            var result = await _controllerGood.GetEmployeeById(1);
            Assert.Equal("3216632325", result.PhoneNumber);
        }

        [Fact]
        public async Task VerifyEmployeePhoneNumberSingleRecord_WrongPhoneNumber_Success()
        {
            var result = await _controllerWrong.GetEmployeeById(1);
            Assert.Equal("8002472020", result.PhoneNumber);
        }


        [Fact]
        public async Task VerifyEmployeePaymentIsZero_ValidEmployeeRecord_Success()
        {
            var result = await _controllerWrong.GetEmployeeById(1);
            Assert.Equal(0, result.WorkingHours);
            Assert.Equal(0, result.WeekPayment);
            Assert.Equal(0, result.WeekPaymentTotal);
        }

        [Fact]
        public async Task VerifyEmployeeBonus_ValidEmployeeRecord_NoBonus()
        {
            var result = await _controllerWrong.GetEmployeeById(1);
            Assert.Equal(0, result.Bonus);
        }

        [Fact]
        public async Task VerifyEmployeeBonus_ValidEmployeeRecord_Bonus()
        {
            var result = await _controllerGood.GetEmployeeById(1);
            Assert.True(result.Bonus > 0);
        }
        
        [Fact]
        public async Task VerifyPayment_ValidEmployeeRecordWithBonus_WeekTotalPaymentIsGreaterThanRegularPayment()
        {
            var result = await _controllerGood.GetEmployeeById(1);
            Assert.True(result.Bonus > 0);
            Assert.True(result.WeekPaymentTotal > result.WeekPayment);
        }
        
        [Fact]
        public async Task VerifyPayment_ValidEmployeeRecordWithNoBonus_WeekTotalPaymentIsEqualThanRegularPayment()
        {
            var result = await _controllerWrong.GetEmployeeById(1);
            Assert.True(result.Bonus == 0);
            Assert.True(result.WeekPaymentTotal == result.WeekPayment);
        }

        [Fact]
        public async Task VerifyAvailableEmployees_ValidListWithLessThan2ActiveEmployees_EmptyList()
        {
            var result = await _controllerEmpty.GetAllEmployees() ;
            Assert.False(result.Any());            
        }

        [Fact]
        public async Task VerifyAdminEmployees_ValidListWithNoAdmins_EmptyList()
        {
            var result = await _controllerEmpty.GetAllEmployees();
            Assert.False(result.Any());
        }
    }
}
