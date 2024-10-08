using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Application.Interfaces;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.ConsoleApp.Components.Menu;
using ProjectManagementSystem.ConsoleApp.Components.MenuPages;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;
using ProjectManagementSystem.Infrastructure.HashService;
using ProjectManagementSystem.SQLiteDb;
using ProjectManagementSystem.SQLiteDb.Entities;
using ProjectManagementSystem.SQLiteDb.Mappers;
using ProjectManagementSystem.SQLiteDb.Repositories;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.ConsoleApp.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddAppServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<UserAuthenticationService>();
        serviceCollection.AddSingleton<TaskService>();
        serviceCollection.AddSingleton<TaskStatusService>();
        serviceCollection.AddSingleton<UserService>();
        serviceCollection.AddSingleton<ChangeOfTaskStatusService>();
        return serviceCollection;
    }
    
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IPasswordHasher, PasswordHasher>();
        return serviceCollection;
    }

    public static IServiceCollection AddSqLiteDbContextFactory(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<Func<ProjectManagementSystemSQLiteDbContext>>(sp => CreateSqLiteDbContext);
        return serviceCollection;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IUserRepository, SqLiteUserRepository>();
        serviceCollection.AddTransient<IProjectTaskRepository, SqLiteProjectTaskRepository>();
        serviceCollection.AddTransient<ITaskStatusRepository, SqLiteTaskStatusRepository>();
        serviceCollection.AddTransient<IChangeOfTaskStatusRepository, SqLiteChangeOfTaskStatusRepository>();
        return serviceCollection;
    }

    public static IServiceCollection AddMappersForDb(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddSingleton<IMapper<UserEntity, User>, MapperUserEntityToUser>();
        serviceCollection
            .AddSingleton<IMapper<ProjectTaskEntity, ProjectTask>, DeepMapperProjectTaskEntityToProjectTask>();
        serviceCollection
            .AddSingleton<IMapper<TaskStatusEntity, TaskStatus>, MapperTaskStatusEntityToTaskStatus>();
        serviceCollection
            .AddSingleton<IMapper<ChangeOfTaskStatusEntity, ChangeOfTaskStatus>,
                MapperChangeOfTaskStatusEntityToChangeOfTaskStatus>();
        return serviceCollection;
    }

    public static IServiceCollection AddMenuPages(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<TaskListOrdinaryEmployeeMenuPage>();
        serviceCollection.AddSingleton<ChangeTaskDataOrdinaryEmployeeMenuPage>();
        serviceCollection.AddSingleton<MainSupervisorMenuPage>();
        serviceCollection.AddSingleton<RegistrationNewUserMenuPage>();
        serviceCollection.AddSingleton<CreateNewProjectTaskMenuPage>();
        serviceCollection.AddSingleton<AssignProjectTaskToUserMenuPage>();
        return serviceCollection;
    }

    public static IServiceCollection AddDtos(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<SystemMenuPagesDTO>();
        return serviceCollection;
    }

    private static ProjectManagementSystemSQLiteDbContext CreateSqLiteDbContext() =>
        new ProjectManagementSystemSQLiteDbContext();
    
}