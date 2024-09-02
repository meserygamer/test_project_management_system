using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.Core.RepositoryInterfaces;

public interface IProjectTaskRepository
{
    Task<List<ProjectTask>> GetAllUsersTasksAsync(int userId);
}