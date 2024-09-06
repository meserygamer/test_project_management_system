using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.SQLiteDb.Entities;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.SQLiteDb.Mappers;

public class DeepMapperProjectTaskEntityToProjectTask : IMapper<ProjectTaskEntity, ProjectTask>
{
    MapperTaskStatusEntityToTaskStatus _statusMapper = new MapperTaskStatusEntityToTaskStatus();
    MapperUserEntityToUser _userMapper = new MapperUserEntityToUser();
    
    public ProjectTask MapToDestination(ProjectTaskEntity source)
    {
        ProjectTask task = new ProjectTask
        {
            Id = source.Id,
            Title = source.Title,
            Description = source.Description,
            StartTime = source.StartTime,
            TaskStatus = _statusMapper.MapToDestination(source.TaskStatus)
        };
        if (source.ResponsibleUser is not null)
            task.ResponsibleUser = _userMapper.MapToDestination(source.ResponsibleUser);
        
        return task;
    }

    public ProjectTaskEntity MapToSource(ProjectTask destination)
    {
        ProjectTaskEntity task = new ProjectTaskEntity()
        {
            Id = destination.Id,
            Title = destination.Title,
            Description = destination.Description,
            StartTime = destination.StartTime,
            TaskStatusId = destination.TaskStatus.Id,
        };
        if (destination.ResponsibleUser is not null)
            task.ResponsibleUserId = destination.ResponsibleUser.Id;

        return task;
    }
}