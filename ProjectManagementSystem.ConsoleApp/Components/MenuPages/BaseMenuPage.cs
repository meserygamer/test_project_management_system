using ProjectManagementSystem.ConsoleApp.Components.Menu;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Infrastructure;

namespace ProjectManagementSystem.ConsoleApp.Components.MenuPages;

public abstract class BaseMenuPage
{
    public User? User { get; set; }

    public Bundle? SavedData { get; set; }

    public SystemMenu ParentMenu { get; set; } = null!;

    public abstract Task OpenPageAsync();

    public abstract void LeavePage();
}