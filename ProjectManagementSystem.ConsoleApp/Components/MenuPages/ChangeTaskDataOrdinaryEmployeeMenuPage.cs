using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.ConsoleApp.Extensions;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Infrastructure;
using TaskStatus = ProjectManagementSystem.Core.DomainEntities.TaskStatus;

namespace ProjectManagementSystem.ConsoleApp.Components.MenuPages;

public class ChangeTaskDataOrdinaryEmployeeMenuPage : BaseMenuPage
{
    private readonly TaskService _taskService;
    private readonly TaskStatusService _taskStatusService;
    
    private int _changeTaskId;

    private List<TaskStatus>? _taskStatuses;

    public ChangeTaskDataOrdinaryEmployeeMenuPage(
        TaskService taskService,
        TaskStatusService taskStatusService
        )
    {
        _taskService = taskService;
        _taskStatusService = taskStatusService;
    }
    
    public override async Task OpenPageAsync()
    {
        if (base.ParentMenu is null) 
            throw new NullReferenceException($"{nameof(base.ParentMenu)} was null");
        
        if (base.User is null) 
            throw new NullReferenceException($"{nameof(base.User)} was null");
        
        SetChangeTaskIdFromBundle();
        
        await PrintTaskAndPossibleChangesAsync();
        int? userChoice = await ConsoleExtension.GetOptionNumberFromConsoleWithDenyAsync(
                PrintInputNumberOfStatusErrorAsync,
                ["n", "N"],
                1,
                _taskStatuses!.Count
                );
        
        if (userChoice is not null)
            await _taskService.UpdateStatusForTaskAsync(_changeTaskId,
                _taskStatuses![(int)userChoice - 1].Id, User.Id);
                
        await base.ParentMenu.ChangePageWithOpenAsync(
            typeof(TaskListOrdinaryEmployeeMenuPage),
            null
            );
    }

    public override void LeavePage()
    {
        Console.Clear();
    }

    private void SetChangeTaskIdFromBundle()
    {
        Bundle dataFromPreviousPage = base.SavedData ?? throw new NullReferenceException($"Bundle was null");
        _changeTaskId = dataFromPreviousPage.GetData<int>(TaskListOrdinaryEmployeeMenuPage.KeyOfChosenTaskId);
    }

    private async Task PrintTaskAndPossibleChangesAsync()
    {
        await PrintTaskInfoAsync();
        Console.WriteLine($"Выберите новый статус для задачи (Введите номер или n/N для возврата к просмотру списка задач):");
        await PrintPossibleStatusesForTask();
    }
    
    private async Task PrintInputNumberOfStatusErrorAsync()
    {
        Console.Clear();
        await PrintTaskInfoAsync();
        Console.WriteLine("Некорректный ввод! Повторите попытку (Введите номер или n/N для возврата к просмотру списка задач):");
        await PrintPossibleStatusesForTask(false);
    }

    private async Task PrintTaskInfoAsync()
    {
        ProjectTask projectTask = await _taskService.GetTaskByIdAsync(_changeTaskId) 
                                  ?? throw new SystemException("Task id was incorrect");
        Console.WriteLine(projectTask.ProjectTaskInfo);
    }

    private async Task PrintPossibleStatusesForTask(bool isNeedLoadTasks = true)
    {
        if(isNeedLoadTasks) 
            _taskStatuses = await _taskStatusService.GetAllStatusesAsync();
        
        for (int i = 0; i < (_taskStatuses?.Count ?? 0); i++) 
            Console.WriteLine($"{i+1}) {_taskStatuses[i].Title}");

        Console.WriteLine();
    }
}