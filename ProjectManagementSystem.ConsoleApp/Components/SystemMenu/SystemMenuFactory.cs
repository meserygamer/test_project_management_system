using ProjectManagementSystem.ConsoleApp.Components.SystemMenu.MenuPages;
using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu;

public class SystemMenuFactory
{
    private readonly Dictionary<UserRole, Func<User, SystemMenu>> _menusOfRoles;

    public SystemMenuFactory(SystemMenuPagesDTO systemMenuPagesDto)
    {
        _menusOfRoles = new() 
        { 
            { UserRole.Supervisor, user => new SystemMenu(user, systemMenuPagesDto, null) }, 
            { UserRole.OrdinaryEmployee, user => new SystemMenu(user, systemMenuPagesDto, typeof(TaskListOrdinaryEmployeeMenuPage)) } 
        };
    }
    
    public SystemMenu CreateMenu(User user)
    {
        if (!_menusOfRoles.TryGetValue(user.Role, out Func<User, SystemMenu>? concreteMenuFactory))
            throw new NotImplementedException("Wrong role");

        return concreteMenuFactory.Invoke(user);
    }
}