using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Application.Interfaces;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;
using ProjectManagementSystem.Infrastructure.HashService;
using ProjectManagementSystem.SQLiteDb;
using ProjectManagementSystem.SQLiteDb.Entities;
using ProjectManagementSystem.SQLiteDb.Mappers;
using ProjectManagementSystem.SQLiteDb.Repositories;

namespace ProjectManagementSystem.ConsoleApp.Extensions;

public static class ServiceCollectionExtension
{
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
        serviceCollection.AddTransient<IUserRepository, SQLiteUserRepository>();
        return serviceCollection;
    }

    public static IServiceCollection AddMappersForDb(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMapper<UserEntity, User>, MapperUserEntityToUser>();
        return serviceCollection;
    }

    private static ProjectManagementSystemSQLiteDbContext CreateSqLiteDbContext() =>
        new ProjectManagementSystemSQLiteDbContext();
}