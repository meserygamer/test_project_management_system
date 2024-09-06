using System.ComponentModel.DataAnnotations;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.ConsoleApp.Extensions;
using ProjectManagementSystem.Core.DomainEntities;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.ConsoleApp.Components.MenuPages;

public class CreateNewProjectTaskMenuPage : BaseMenuPage
{
    private readonly TaskStatusService _taskStatusService;
    private readonly TaskService _taskService;

    private List<TaskStatus> _possibleTaskStatusList = new();
    
    private ProjectTask _newProjectTask = new();

    public CreateNewProjectTaskMenuPage(
        TaskStatusService taskStatusService,
        TaskService taskService
        )
    {
        _taskStatusService = taskStatusService;
        _taskService = taskService;
    }
    
    public override async Task OpenPageAsync()
    {
        if (base.ParentMenu is null)
            throw new NullReferenceException($"{nameof(base.ParentMenu)} was null");
        
        _possibleTaskStatusList = await _taskStatusService.GetAllStatusesAsync();
        _newProjectTask = new ProjectTask
        {
            Title = GetTaskTitleFromUser(),
            Description = GetTaskDescriptionFromUser(),
            StartTime = GetTaskStartTimeFromUser(),
            TaskStatus = GetTaskStatusFromUser()
        };
        
        Console.Clear();
        if (await _taskService.TryAddProjectTaskAsync(_newProjectTask))
            Console.WriteLine("Задача добавлена!");
        else
            Console.WriteLine("Неизвестная ошибка!\n" +
                              "Задача не была добавлена!");
        Console.WriteLine("Для возвращения в меню нажмите enter");
        Console.ReadKey();
        
        await base.ParentMenu.ChangePageWithOpenAsync(typeof(MainSupervisorMenuPage), null);
    }

    public override void LeavePage()
    {
        Console.Clear();
    }

    private string GetTaskTitleFromUser()
    {
        Console.Clear();
        List<ValidationAttribute> validationAttributes = [
            new RequiredAttribute 
            { 
                AllowEmptyStrings = false, 
                ErrorMessage = "Название задачи не должно быть пустым!" 
            }, 
            new MaxLengthAttribute(150)
            {
                ErrorMessage = "Название задачи не должно превышать 150 символов!"
            }
        ];
        return ConsoleExtension.GetStringFromConsoleWithValidation(
            "Введите название задачи (не пустое):",
            "Название задачи некорректно!",
            validationAttributes
        );
    }

    private string GetTaskDescriptionFromUser()
    {
        Console.Clear();
        Console.WriteLine("Введите описание задачи (необязательно):");
        return Console.ReadLine() ?? string.Empty;
    }

    private DateTime GetTaskStartTimeFromUser()
    {
        DateTime value;
        Console.Clear();
        while (true)
        {
            Console.WriteLine("Введите время выдачи задачи (Пример: 18/08/2018 07:22:16):");
            if (ConsoleExtension.TryGetDatetime(out value))
                break;
            
            Console.Clear();
            Console.WriteLine("Некорректное время!");
        }
        return value;
    }

    private TaskStatus GetTaskStatusFromUser()
    {
        PrintPossibleTaskStatuses();
        int chosenStatusIndex = ConsoleExtension.GetOptionNumberFromConsole(
            PrintInputErrorOfTaskStatus,
            1,
            _possibleTaskStatusList.Count
        );
        return _possibleTaskStatusList[chosenStatusIndex - 1];
    }

    private void PrintPossibleTaskStatuses()
    {
        Console.Clear();
        Console.WriteLine("Выберите первоначальный статус задачи:");
        PrintPossibleTaskStatusesList();
    }

    private void PrintInputErrorOfTaskStatus()
    {
        Console.Clear();
        Console.WriteLine("Некорректный выбор статуса! Повторите попытку");
        Console.WriteLine("Выберите первоначальный статус задачи:");
        PrintPossibleTaskStatusesList();
    }

    private void PrintPossibleTaskStatusesList()
    {
        for (int i = 0; i < _possibleTaskStatusList.Count; i++) 
            Console.WriteLine($"{i+1}) {_possibleTaskStatusList[i].Title}");
    }
}