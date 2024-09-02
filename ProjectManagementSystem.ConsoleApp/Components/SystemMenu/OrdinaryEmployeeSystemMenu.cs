using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu;

public class OrdinaryEmployeeSystemMenu : BaseSystemMenu
{
    private readonly TaskService _taskService;

    public OrdinaryEmployeeSystemMenu(User user, TaskService taskService) : base(user)
    {
        _taskService = taskService;
    }
    
    public override async Task EnterInSystemAsync()
    {
        await PrintMainPageAsync();
    }

    private async Task PrintMainPageAsync()
    {
        Console.Clear();
        Console.WriteLine($"Здравствуйте, {User.FullName}");
        Console.WriteLine("Список ваших задач:\n");
        await PrintUsersTasksAsync();
    }

    private async Task PrintUsersTasksAsync()
    {
        List<ProjectTask> usersProjectTasks = await _taskService.GetAllUsersTaskAsync(User.Id);
        foreach (var task in usersProjectTasks) 
            Console.WriteLine(
                $"Номер задачи: {task.Id}\n" + 
                $"Заголовок: {task.Title}\n" + 
                $"Описание: {task.Description}\n" + 
                $"Дата начала: {task.StartTime}\n" + 
                $"Статус: {task.TaskStatus.Title}\n"
                );
    }
}