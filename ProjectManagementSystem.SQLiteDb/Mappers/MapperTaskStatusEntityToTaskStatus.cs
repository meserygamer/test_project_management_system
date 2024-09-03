using ProjectManagementSystem.SQLiteDb.Entities;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.SQLiteDb.Mappers;

public class MapperTaskStatusEntityToTaskStatus : IMapper<TaskStatusEntity, TaskStatus>
{
    public TaskStatus MapToDestination(TaskStatusEntity source)
    {
        return new TaskStatus
        {
            Id = source.Id,
            Title = source.Title
        };
    }

    public TaskStatusEntity MapToSource(TaskStatus destination)
    {
        return new TaskStatusEntity
        {
            Id = destination.Id,
            Title = destination.Title
        };
    }
}