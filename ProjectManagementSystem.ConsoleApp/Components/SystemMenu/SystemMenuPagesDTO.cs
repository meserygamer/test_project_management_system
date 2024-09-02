using ProjectManagementSystem.ConsoleApp.Components.SystemMenu.MenuPages;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu;

public class SystemMenuPagesDTO
{
    public SystemMenuPagesDTO(
        TaskListOrdinaryEmployeeMenuPage taskListOrdinaryEmployeeMenuPage
        )
    {
        MenuPages = new Dictionary<Type, BaseMenuPage>
        {
            { typeof(TaskListOrdinaryEmployeeMenuPage), taskListOrdinaryEmployeeMenuPage }
        };
    }

    public Dictionary<Type, BaseMenuPage> MenuPages { get; set; }
}