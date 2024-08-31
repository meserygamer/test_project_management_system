using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.Application.Interfaces;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Core.RepositoryInterfaces;
using ProjectManagementSystem.Infrastructure.HashService;
using ProjectManagementSystem.SQLiteDb.Repositories;

namespace ProjectManagementSystem.ConsoleApp;

public static class Startup
{
    public static void Main()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddTransient<UserAuthenticator>();
        services.AddTransient<UserAuthenticationService>();
        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddTransient<IUserRepository, SQLiteUserRepository>();
        ((UserAuthenticator?)services.BuildServiceProvider().GetService(typeof(UserAuthenticator)))?.AuthenticateUser();
    }
}