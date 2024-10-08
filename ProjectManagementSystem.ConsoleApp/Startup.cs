﻿using Microsoft.Extensions.DependencyInjection;
using ProjectManagementSystem.ConsoleApp.Components;
using ProjectManagementSystem.ConsoleApp.Components.Menu;
using ProjectManagementSystem.ConsoleApp.Extensions;
using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp;

public static class Startup
{
    public static async Task Main()
    {
        IServiceCollection services = new ServiceCollection()
            .AddAppServices()
            .AddInfrastructure()
            .AddSqLiteDbContextFactory()
            .AddRepositories()
            .AddMappersForDb()
            .AddMenuPages()
            .AddDtos()
            .AddTransient<UserAuthenticator>()
            .AddSingleton<SystemMenuFactory>();

        ServiceProvider serviceProvider = services.BuildServiceProvider();
        UserAuthenticator userAuthenticator = serviceProvider.GetService<UserAuthenticator>() 
                                              ?? throw new SystemException("UserAuthenticator in DICont was not found");
        User? user = await userAuthenticator.AuthenticateUserAsync();
        
        if (user is null)
            throw new SystemException();

        SystemMenuFactory menuFactory = serviceProvider.GetService<SystemMenuFactory>() 
                                        ?? throw new SystemException("SystemMenuFactory in DICont was not found");
        await menuFactory.CreateMenu(user)
            .OpenMenuAsync();
        
        Console.ReadKey();
    }
}