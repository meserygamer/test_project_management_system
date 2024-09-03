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

    public async Task<ProjectTask?> GetTaskByIdAsync(int taskId)
        => await _projectTaskRepository.GetTaskByIdAsync(taskId);

    public async Task<bool> UpdateStatusForTask(int taskId, int newStatusId)
    {
        ProjectTask task = await GetTaskByIdAsync(taskId) 
                           ?? throw new ArgumentException($"task with id - {taskId} was not found");
        task.TaskStatus.Id = newStatusId;
        return await _projectTaskRepository.UpdateTaskAsync(task);
    }
}