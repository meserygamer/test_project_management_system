using ProjectManagementSystem.ConsoleApp.Components.SystemMenu.MenuPages;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu;

public class SystemMenuPagesDTO
{
    public SystemMenuPagesDTO(
        TaskListOrdinaryEmployeeMenuPage taskListOrdinaryEmployeeMenuPage,
        ChangeTaskDataOrdinaryEmployeeMenuPage changeTaskDataOrdinaryEmployeeMenuPage
        )
    {
        MenuPages = new Dictionary<Type, BaseMenuPage>
        {
            { typeof(TaskListOrdinaryEmployeeMenuPage), taskListOrdinaryEmployeeMenuPage },
            { typeof(ChangeTaskDataOrdinaryEmployeeMenuPage), changeTaskDataOrdinaryEmployeeMenuPage }
        };
    }

    public Dictionary<Type, BaseMenuPage> MenuPages { get; set; }
}