using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.SQLiteDb.Entities;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.SQLiteDb.Mappers;

public class MapperProjectTaskEntityToProjectTaskWithStatus : IMapper<ProjectTaskEntity, ProjectTask>
{
    public ProjectTask MapToDestination(ProjectTaskEntity source)
    {
        return new ProjectTask
        {
            Id = source.Id,
            Title = source.Title,
            Description = source.Description,
            StartTime = source.StartTime,
            TaskStatus = new TaskStatus
            {
                Id = source.TaskStatus.Id,
                Title = source.TaskStatus.Title
            }
        };
    }

    public ProjectTaskEntity MapToSource(ProjectTask destination)
    {
        return new ProjectTaskEntity()
        {
            Id = destination.Id,
            Title = destination.Title,
            Description = destination.Description,
            StartTime = destination.StartTime,
            TaskStatus = new TaskStatusEntity()
            {
                Id = destination.TaskStatus.Id,
                Title = destination.TaskStatus.Title
            }
        };
    }
}