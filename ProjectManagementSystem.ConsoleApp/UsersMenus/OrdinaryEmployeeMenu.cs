using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.UsersMenus;

public class OrdinaryEmployeeMenu : BaseMenu
{
    public OrdinaryEmployeeMenu(User user) : base(user) { }
    
    public override void ShowMenu()
    {
        throw new NotImplementedException();
    }
}