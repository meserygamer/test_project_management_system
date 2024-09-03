using ProjectManagementSystem.ConsoleApp.Components.MenuPages;

namespace ProjectManagementSystem.ConsoleApp.Components.Menu;

public class SystemMenuPagesDTO
{
    public SystemMenuPagesDTO(
        TaskListOrdinaryEmployeeMenuPage taskListOrdinaryEmployeeMenuPage,
        ChangeTaskDataOrdinaryEmployeeMenuPage changeTaskDataOrdinaryEmployeeMenuPage,
        MainSupervisorMenuPage mainSupervisorMenuPage,
        RegistrationNewUserMenuPage registrationNewUserMenuPage,
        CreateNewProjectTaskMenuPage createNewProjectTaskMenuPage,
        AssignProjectTaskToUserMenuPage assignProjectTaskToUserMenuPage
        )
    {
        MenuPages = new Dictionary<Type, BaseMenuPage>
        {
            { typeof(TaskListOrdinaryEmployeeMenuPage), taskListOrdinaryEmployeeMenuPage },
            { typeof(ChangeTaskDataOrdinaryEmployeeMenuPage), changeTaskDataOrdinaryEmployeeMenuPage },
            { typeof(MainSupervisorMenuPage), mainSupervisorMenuPage },
            { typeof(RegistrationNewUserMenuPage), registrationNewUserMenuPage },
            { typeof(CreateNewProjectTaskMenuPage), createNewProjectTaskMenuPage },
            { typeof(AssignProjectTaskToUserMenuPage), assignProjectTaskToUserMenuPage }
        };
    }

    public Dictionary<Type, BaseMenuPage> MenuPages { get; set; }
}