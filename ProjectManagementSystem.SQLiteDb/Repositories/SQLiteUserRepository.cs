using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;

namespace ProjectManagementSystem.SQLiteDb.Repositories;

public class SQLiteUserRepository : IUserRepository
{
    public List<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User? GetUserByLogin(string login)
    {
        throw new NotImplementedException();
    }
}