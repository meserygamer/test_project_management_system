using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu;

public class SystemMenuFactory
{
    private readonly TaskService _taskService;

    private readonly Dictionary<UserRole, Func<User, BaseSystemMenu>> _menusOfRoles;

    public SystemMenuFactory(TaskService taskService)
    {
        _taskService = taskService;
        
        _menusOfRoles = new() 
        { 
            { UserRole.Supervisor, user => new SupervisorSystemMenu(user) }, 
            { UserRole.OrdinaryEmployee, user => new OrdinaryEmployeeSystemMenu(user, _taskService) } 
        };
    }
    
    public BaseSystemMenu CreateMenu(User user)
    {
        if (!_menusOfRoles.TryGetValue(user.Role, out Func<User, BaseSystemMenu>? concreteMenuFactory))
            throw new NotImplementedException("Wrong role");

        return concreteMenuFactory.Invoke(user);
    }
}