using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.Core.RepositoryInterfaces;

public interface IUserRepository
{
    List<User> GetAllUsers();
    User? GetUserByLogin(string login);
}