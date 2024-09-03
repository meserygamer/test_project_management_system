using ProjectManagementSystem.Core.RepositoryInterfaces;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.Application.Services;

public class TaskStatusService
{
    private readonly ITaskStatusRepository _taskStatusRepository;
    
    public TaskStatusService(ITaskStatusRepository taskStatusRepository)
    {
        _taskStatusRepository = taskStatusRepository;
    }

    public async Task<List<TaskStatus>> GetAllStatusesAsync()
        => await _taskStatusRepository.GetAllStatusesAsync();
}