namespace ProjectManagementSystem.Core.RepositoryInterfaces;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

public interface ITaskStatusRepository
{
    Task<List<TaskStatus>> GetAllStatusesAsync();
}