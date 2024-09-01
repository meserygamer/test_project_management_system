using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.UsersMenus;

public abstract class BaseMenu
{
    protected readonly User User;

    protected BaseMenu(User user)
    {
        User = user;
    }

    public abstract void ShowMenu();
}