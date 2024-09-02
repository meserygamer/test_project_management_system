using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.ConsoleApp.Extensions;
using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu.MenuPages;

public class TaskListOrdinaryEmployeeMenuPage : BaseMenuPage
{
    private readonly TaskService _taskService;

    private List<ProjectTask> _usersProjectTasks = null!;

    public TaskListOrdinaryEmployeeMenuPage(TaskService taskService)
    {
        _taskService = taskService;
    }
    
    public override async Task OpenPageAsync()
    {
        Console.WriteLine($"Здравствуйте, {base.User.FullName}\n");
        await PrintUsersTasksAsync();
        try
        {
            GetTaskNumberFromConsole();
        }
        catch (Exception e)
        {
            
        }
    }

    public override void LeavePage() => Console.Clear();

    private int GetTaskNumberFromConsole(Action caseOfInputError)
    {
        int numberTaskForEditing = 0;
        bool isRightInput = false;
        while (!isRightInput)
        {
            Console.WriteLine("Для редактирования задачи введите её номер:\n");
            if (ConsoleExtension.TryGetInt32(out numberTaskForEditing)
                && _usersProjectTasks.Find(pt => pt.Id == numberTaskForEditing) is not null)
                isRightInput = true;
            
        }

        return numberTaskForEditing;
    }
    
    private async Task PrintUsersTasksAsync()
    {
        Console.WriteLine("Список ваших задач:\n");
        _usersProjectTasks = await _taskService.GetAllUsersTaskAsync(User.Id);
        foreach (var task in _usersProjectTasks) 
            Console.WriteLine(
                $"Номер задачи: {task.Id}\n" + 
                $"Заголовок: {task.Title}\n" + 
                $"Описание: {task.Description}\n" + 
                $"Дата начала: {task.StartTime}\n" + 
                $"Статус: {task.TaskStatus.Title}\n"
            );
    }
}