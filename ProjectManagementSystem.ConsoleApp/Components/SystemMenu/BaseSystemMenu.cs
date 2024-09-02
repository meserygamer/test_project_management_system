using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu;

public abstract class BaseSystemMenu
{
    protected readonly User User;

    protected BaseSystemMenu(User user)
    {
        User = user;
    }

    public abstract Task EnterInSystemAsync();
}