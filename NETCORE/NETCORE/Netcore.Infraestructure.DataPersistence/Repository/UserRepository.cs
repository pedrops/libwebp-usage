using NetCore.Domain.Abstractions.Repository;
using NetCore.Domain.Entities;
using NetCore.Domain.Entities.Constants;

namespace NetCore.Infraestructure.DataPersistence.Repository
{
    public class UserRepository : DBBase, IUserRepository
    {
        public UserRepository(DapperContext context) : base(context)
        {
        }

        public async Task AddUser(User user)
        {
            var query = $"INSERT INTO {DatabaseTables.User} " +
                        $"([UserName] " +
                        $",[Password]) " +
                        $" VALUES" +
                        $"(@username " +
                        $",@password) ";
            var result = (await ExecuteQuery<User>(
                query,
                new
                {
                    @username = user.UserName,
                    @password = user.Password
                }));
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var result = (await ExecuteQuery<User>(
                $"SELECT *" +
                $" FROM {DatabaseTables.User} ")).ToList();
            return result;
        }

        public async Task RemoveUser(int Id)
        {
            var query = $"DELETE FROM {DatabaseTables.User} WHERE [Id] = {Id}";
            var result = (await ExecuteQuery<User>(query)).ToList();
        }
        public async Task<string> GetPasswordByUserName(string userName)
        {
            var query = 
                $"SELECT [Password] " +
                $" FROM {DatabaseTables.User} "+
                $" WHERE [UserName] LIKE '%{userName}%'";
            var result = (await ExecuteQuery<string>(query)).FirstOrDefault();
            return result;
        }

        public async Task UpdateUser(User user)
        {
            var query = $"INSERT INTO {DatabaseTables.User} " +
            $" [UserName] = @username  " +
            $",[Password] = @password) " +
            $" WHERE [Id] = {user.Id}";
            var result = (await ExecuteQuery<User>(
                query,
                new
                {
                    @username = user.UserName,
                    @password = user.Password
                }));
        }
    }
}
