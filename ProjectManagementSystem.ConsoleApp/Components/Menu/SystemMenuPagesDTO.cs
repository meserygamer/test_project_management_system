using ProjectManagementSystem.ConsoleApp.Components.MenuPages;

namespace ProjectManagementSystem.ConsoleApp.Components.Menu;

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