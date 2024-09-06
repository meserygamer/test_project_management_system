using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.ConsoleApp.Extensions;
using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.MenuPages;

public class AssignProjectTaskToUserMenuPage : BaseMenuPage
{
    private readonly TaskService _taskService;
    private readonly UserService _userService;
    
    private List<ProjectTask> _projectTasks = new();
    private List<User> _users = new();

    public AssignProjectTaskToUserMenuPage(
        TaskService taskService,
        UserService userService
        )
    {
        _taskService = taskService;
        _userService = userService;
    }
    
    public override async Task OpenPageAsync()
    {
        if (base.ParentMenu is null)
            throw new NullReferenceException($"{nameof(base.ParentMenu)} was null");
        
        _projectTasks = await _taskService.GetAllTasksAsync();
        _users = await _userService.GetAllUsersAsync();
            
        int taskOnChangeIndex = GetIndexOfProjectTaskOnChangeResponsible();
        int newResponsibleUserIndex = GetIndexOfNewResponsibleUser();
        
        Console.Clear();
        if (await _taskService.UpdateResponsibleForTaskAsync(taskOnChangeIndex, newResponsibleUserIndex))
            Console.WriteLine("Ответсвенный за задачу сменён!");
        else
            Console.WriteLine("Неизвестная ошибка!\n" +
                              "Ответсвенный за задачу не сменился!");
        
        Console.WriteLine("Для возвращения в меню нажмите enter");
        Console.ReadKey();
        
        await base.ParentMenu.ChangePageWithOpenAsync(typeof(MainSupervisorMenuPage), null);
    }

    public override void LeavePage()
    {
        Console.Clear();
    }

    private int GetIndexOfProjectTaskOnChangeResponsible()
    {
        PrintTasksForChangeResponsible();
        return GetTaskNumberFromConsole(PrintErrorOfChoiceTaskForChange);
    }

    private int GetIndexOfNewResponsibleUser()
    {
        PrintEmployeeCandidates();
        return GetUserNumberFromConsole(PrintErrorOfChoiceEmployee);
    }
    
    private int GetTaskNumberFromConsole(Action inputErrorHandler)
    {
        int numberTaskForEditing = 0;
        while (true)
        {
            if (ConsoleExtension.TryGetInt32(out numberTaskForEditing)
                && _projectTasks.Find(pt => pt.Id == numberTaskForEditing) is not null) 
                break;
            
            if(inputErrorHandler is not null) 
                inputErrorHandler.Invoke();
        }

        return numberTaskForEditing;
    }
    
    private int GetUserNumberFromConsole(Action inputErrorHandler)
    {
        int numberUser = 0;
        while (true)
        {
            if (ConsoleExtension.TryGetInt32(out numberUser)
                && _users.Find(pt => pt.Id == numberUser) is not null) 
                break;
            
            if(inputErrorHandler is not null) 
                inputErrorHandler.Invoke();
        }

        return numberUser;
    }

    private void PrintTasksForChangeResponsible()
    {
        Console.Clear();
        PrintTasks();
        Console.WriteLine("Выберите задачу для смены ответственного (Введите её номер):");
    }

    private void PrintErrorOfChoiceTaskForChange()
    {
        Console.Clear();
        PrintTasks();
        Console.WriteLine("Введённый номер задачи некорректен!");
        Console.WriteLine("Выберите задачу для смены ответственного (Введите её номер):");
    }
    
    private void PrintTasks()
    {
        Console.WriteLine("Список задач:\n");
        foreach (var task in _projectTasks) 
            Console.WriteLine(task.ProjectTaskInfoWithResponsible);
    }

    private void PrintEmployeeCandidates()
    {
        Console.Clear();
        PrintUsers();
        Console.WriteLine("Выберите ответственного (Введите его номер):");
    }

    private void PrintErrorOfChoiceEmployee()
    {
        Console.Clear();
        PrintUsers();
        Console.WriteLine("Некорректный номер пользователя!");
        Console.WriteLine("Выберите ответственного (Введите его номер):");
    }

    private void PrintUsers()
    {
        Console.WriteLine("Список работников:\n");
        foreach (var user in _users)
            Console.WriteLine(user.UserInfo);
    }
}