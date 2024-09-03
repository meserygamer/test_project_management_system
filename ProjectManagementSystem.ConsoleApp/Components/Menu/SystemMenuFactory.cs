using ProjectManagementSystem.ConsoleApp.Components.MenuPages;
using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.Menu;

public class SystemMenuFactory
{
    private readonly Dictionary<UserRole, Func<User, Menu.SystemMenu>> _menusOfRoles;

    public SystemMenuFactory(SystemMenuPagesDTO systemMenuPagesDto)
    {
        _menusOfRoles = new() 
        { 
            { UserRole.Supervisor, user => new Menu.SystemMenu(user, systemMenuPagesDto, typeof(MainSupervisorMenuPage)) }, 
            { UserRole.OrdinaryEmployee, user => new Menu.SystemMenu(user, systemMenuPagesDto, typeof(TaskListOrdinaryEmployeeMenuPage)) } 
        };
    }
    
    public Menu.SystemMenu CreateMenu(User user)
    {
        if (!_menusOfRoles.TryGetValue(user.Role, out Func<User, Menu.SystemMenu>? concreteMenuFactory))
            throw new NotImplementedException("Wrong role");

        return concreteMenuFactory.Invoke(user);
    }
}