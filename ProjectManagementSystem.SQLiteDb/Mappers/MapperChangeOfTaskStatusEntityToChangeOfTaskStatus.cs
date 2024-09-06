using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.SQLiteDb.Entities;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.SQLiteDb.Mappers;

public class MapperChangeOfTaskStatusEntityToChangeOfTaskStatus : IMapper<ChangeOfTaskStatusEntity, ChangeOfTaskStatus>
{
    public ChangeOfTaskStatus MapToDestination(ChangeOfTaskStatusEntity source)
    {
        ChangeOfTaskStatus changeOfTaskStatus = new ChangeOfTaskStatus()
        {
            Id = source.Id,
            ChangeDate = source.ChangeDate,
            NewStatus = new TaskStatus
            {
                Id = source.NewStatusId
            },
            Task = new ProjectTask
            {
                Id = source.TaskId
            },
            User = new User
            {
                Id = source.UserId
            }
        };
        return changeOfTaskStatus;
    }

    public ChangeOfTaskStatusEntity MapToSource(ChangeOfTaskStatus destination)
    {
        ChangeOfTaskStatusEntity changeOfTaskStatusEntity = new ChangeOfTaskStatusEntity()
        {
            Id = destination.Id,
            ChangeDate = destination.ChangeDate,
            NewStatusId = destination.NewStatus.Id,
            TaskId = destination.Task.Id,
            UserId = destination.User.Id
        };
        return changeOfTaskStatusEntity;
    }
}