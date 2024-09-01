using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.UsersMenus;

public class MenuFactory
{
    private readonly Dictionary<UserRole, Func<User, BaseMenu>> _menusOfRoles = new() 
        { 
            { UserRole.Supervisor, user => new SupervisorMenu(user) }, 
            { UserRole.OrdinaryEmployee, user => new OrdinaryEmployeeMenu(user) } 
        };
    
    public BaseMenu CreateMenu(User user)
    {
        if (!_menusOfRoles.TryGetValue(user.Role, out Func<User, BaseMenu>? concreteMenuFactory))
            throw new NotImplementedException("Wrong role");

        return concreteMenuFactory.Invoke(user);
    }
}