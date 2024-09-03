using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.SQLiteDb.Entities;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.SQLiteDb.Mappers;

public class MapperProjectTaskEntityToProjectTaskWithStatus : IMapper<ProjectTaskEntity, ProjectTask>
{
    public ProjectTask MapToDestination(ProjectTaskEntity source)
    {
        ProjectTask task = new ProjectTask
        {
            Id = source.Id,
            Title = source.Title,
            Description = source.Description,
            StartTime = source.StartTime,
            TaskStatus = new TaskStatus
            {
                Id = source.TaskStatusId
            },
            ResponsibleUser = new User()
            {
                Id = source.ResponsibleUserId
            }
        };
        if (source.TaskStatus is not null)
            task.TaskStatus.Title = source.TaskStatus.Title;

        return task;
    }

    public ProjectTaskEntity MapToSource(ProjectTask destination)
    {
        return new ProjectTaskEntity()
        {
            Id = destination.Id,
            Title = destination.Title,
            Description = destination.Description,
            StartTime = destination.StartTime,
            TaskStatusId = destination.TaskStatus.Id,
            ResponsibleUserId = destination.ResponsibleUser.Id
        };
    }
}