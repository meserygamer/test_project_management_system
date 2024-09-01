using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Application.Interfaces;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.ConsoleApp.Extensions;
using ProjectManagementSystem.ConsoleApp.UsersMenus;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;
using ProjectManagementSystem.Infrastructure.HashService;
using ProjectManagementSystem.SQLiteDb.Repositories;

namespace ProjectManagementSystem.ConsoleApp;

public static class Startup
{
    public static async Task Main()
    {
        IServiceCollection services = new ServiceCollection()
            .AddTransient<UserAuthenticator>()
            .AddTransient<UserAuthenticationService>()
            .AddSingleton<MenuFactory>()
            .AddInfrastructure()
            .AddSqLiteDbContextFactory()
            .AddRepositories()
            .AddMappersForDb();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        UserAuthenticator userAuthenticator = serviceProvider.GetService<UserAuthenticator>() 
                                              ?? throw new SystemException("UserAuthenticator in DICont was not found");
        User? user = await userAuthenticator.AuthenticateUserAsync();
        
        if (user is null)
            throw new SystemException();

        serviceProvider.GetService<MenuFactory>()?
            .CreateMenu(user)
            .ShowMenu();
    }
}