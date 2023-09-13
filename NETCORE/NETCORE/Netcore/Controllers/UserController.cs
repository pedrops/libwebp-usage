using Microsoft.AspNetCore.Mvc;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities.DTO;

namespace Netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Route("ValidateSession")]
        public async Task<bool> ValidateSession(string username, string password)
        {
            return (await _userService.ValidateSession(username,password));
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }

        [HttpPost]
        public async void AddUser(UserDTO user)
        {
            await _userService.AddUser(user);
        }

        [HttpPut]
        public async void UpdateUser(UserDTO user)
        {

            await _userService.UpdateUser(user);
        }

        [HttpDelete]
        public void RemoveUser(int Id)
        {

            _userService.RemoveUser(Id);
        }
    }
}
