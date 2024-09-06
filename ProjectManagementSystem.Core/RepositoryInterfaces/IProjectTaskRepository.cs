using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.Core.RepositoryInterfaces;

public interface IProjectTaskRepository
{
    Task<List<ProjectTask>> GetAllTasksAsync();
    Task<List<ProjectTask>> GetAllUsersTasksAsync(int userId);
    Task<ProjectTask?> GetTaskByIdAsync(int taskId);
    Task<bool> UpdateTaskAsync(ProjectTask newTaskData);
    Task<bool> TryAddProjectTaskAsync(ProjectTask projectTask);
}