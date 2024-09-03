using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.SQLiteDb.Entities;

namespace ProjectManagementSystem.SQLiteDb.Mappers;

public class MapperUserEntityToUser : IMapper<UserEntity, User>
{
    public User MapToDestination(UserEntity source)
    {
        return new User()
        {
            Id = source.Id,
            Login = source.Login,
            HashedPassword = source.HashedPassword,
            Email = source.Email,
            Name = source.Name,
            Surname = source.Surname,
            Patronymic = source.Patronymic,
            Role = (UserRole)source.UserRoleId
        };
    }

    public UserEntity MapToSource(User destination)
    {
        return new UserEntity()
        {
            Id = destination.Id,
            Login = destination.Login,
            HashedPassword = destination.HashedPassword,
            Email = destination.Email,
            Name = destination.Name,
            Surname = destination.Surname,
            Patronymic = destination.Patronymic,
            UserRoleId = (int)destination.Role,
            ChangesTasksStatus = new List<ChangeOfTaskStatusEntity>(),
            Tasks = new List<ProjectTaskEntity>()
        };
    }
}