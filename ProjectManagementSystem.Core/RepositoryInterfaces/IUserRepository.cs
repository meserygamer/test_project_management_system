using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.Core.RepositoryInterfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserByLoginAsync(string login);
}