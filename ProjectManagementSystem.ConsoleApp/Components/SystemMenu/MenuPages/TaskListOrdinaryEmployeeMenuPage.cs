using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.ConsoleApp.Extensions;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Infrastructure;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu.MenuPages;

public class TaskListOrdinaryEmployeeMenuPage : BaseMenuPage
{
    public const string KeyOfChosenTaskId = "NumberOfChosenTask";
    
    private readonly TaskService _taskService;

    private List<ProjectTask> _usersProjectTasks = null!;

    public TaskListOrdinaryEmployeeMenuPage(TaskService taskService)
    {
        _taskService = taskService;
    }
    
    public override async Task OpenPageAsync()
    {
        if (base.User is null)
            throw new NullReferenceException($"{nameof(base.User)} was null");
        
        if (base.ParentMenu is null)
            throw new NullReferenceException($"{nameof(base.ParentMenu)} was null");
        
        await PrintPageAsync();
        int numberOfProjectTaskForEditing = await GetTaskNumberFromConsoleAsync(PrintInputNumberOfTaskErrorAsync);
        await base.ParentMenu.ChangePageWithOpenAsync(
            typeof(ChangeTaskDataOrdinaryEmployeeMenuPage),
            CreateBundleWithNumberOfChosenTask(numberOfProjectTaskForEditing)
            );
    }

    public override void LeavePage() => Console.Clear();

    private async Task PrintPageAsync()
    {
        Console.Clear();
        Console.WriteLine($"Здравствуйте сотрудник, {base.User.FullName}\n");
        await PrintUsersTasksAsync();
        Console.WriteLine("Для редактирования задачи введите её номер:\n");
    }

    private async Task PrintInputNumberOfTaskErrorAsync()
    {
        Console.Clear();
        Console.WriteLine($"Здравствуйте сотрудник, {base.User.FullName}\n");
        await PrintUsersTasksAsync(false);
        Console.WriteLine("Номер задачи введён некорректно!");
        Console.WriteLine("Для редактирования задачи введите её номер:\n");
    }

    private async Task<int> GetTaskNumberFromConsoleAsync(Func<Task> inputErrorHandler)
    {
        int numberTaskForEditing = 0;
        while (true)
        {
            if (ConsoleExtension.TryGetInt32(out numberTaskForEditing)
                && _usersProjectTasks.Find(pt => pt.Id == numberTaskForEditing) is not null) 
                break;
            else
                await inputErrorHandler?.Invoke();
        }

        return numberTaskForEditing;
    }
    
    private async Task PrintUsersTasksAsync(bool isNeedLoadTasks = true)
    {
        Console.WriteLine("Список ваших задач:\n");
        
        if(isNeedLoadTasks) 
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

    private Bundle CreateBundleWithNumberOfChosenTask(int numberOfTask)
    {
        Bundle data = new Bundle();
        data.AddData(KeyOfChosenTaskId, numberOfTask);
        return data;
    }
}