using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu;

public class SupervisorSystemMenu : BaseSystemMenu
{
    public SupervisorSystemMenu(User user) : base(user) { }
    
    public override async Task EnterInSystemAsync()
    {
        throw new NotImplementedException();
    }
}