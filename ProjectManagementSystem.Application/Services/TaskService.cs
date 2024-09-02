using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;

namespace ProjectManagementSystem.Application.Services;

public class TaskService
{
    private readonly IProjectTaskRepository _projectTaskRepository;

    public TaskService(IProjectTaskRepository projectTaskRepository)
    {
        _projectTaskRepository = projectTaskRepository;
    }

    public async Task<List<ProjectTask>> GetAllUsersTaskAsync(int userId) 
        => await _projectTaskRepository.GetAllUsersTasksAsync(userId);
}