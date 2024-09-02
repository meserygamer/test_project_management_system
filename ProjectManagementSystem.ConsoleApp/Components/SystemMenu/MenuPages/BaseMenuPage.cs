using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu.MenuPages;

public abstract class BaseMenuPage
{
    public User User { get; set; }

    public abstract Task OpenPageAsync();

    public abstract void LeavePage();
}