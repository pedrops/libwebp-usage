using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Abstractions.Service;
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.DTO;
using BCrypt;

namespace NetCore.Services.BusinessLogic
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUser(UserDTO userDTO)
        {
            var newUser = new User(userDTO);
            // todo: CHANGE ENCRYPTION
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(userDTO.Password, 8);


            _unitOfWork.UserRepository.AddUser(newUser);
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return (await _unitOfWork.UserRepository.GetAllUsers())
                .Select(x => new UserDTO()
                { 
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.Password
                }); ;
        }

        public async Task RemoveUser(int Id)
        {
            await _unitOfWork.UserRepository.RemoveUser(Id);
        }

        public async Task UpdateUser(UserDTO userDTO)
        {
            var newUser = new User(userDTO);
            await _unitOfWork.UserRepository.UpdateUser(newUser);
        }

        public async Task<bool> ValidateSession(string UserName, string password)
        {
            
            var passwordEncrypted = await _unitOfWork.UserRepository.GetPasswordByUserName(UserName);
            


            if (string.IsNullOrWhiteSpace(passwordEncrypted))
                return false;
            else
                return (BCrypt.Net.BCrypt.Verify(password, passwordEncrypted));
        }
    }
}
