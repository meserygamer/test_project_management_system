using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.Core.RepositoryInterfaces;

public interface IChangeOfTaskStatusRepository
{
    public Task<bool> AddChangeOfTaskStatusAsync(ChangeOfTaskStatus changeOfTaskStatus);
}