using ProjectManagementSystem.Infrastructure;

namespace ProjectManagementSystem.ConsoleApp.Components.SystemMenu.MenuPages;

public class ChangeTaskDataOrdinaryEmployeeMenuPage : BaseMenuPage
{
    private int _changeTaskId; 
    
    public override async Task OpenPageAsync()
    {
        if (base.ParentMenu is null) 
            throw new NullReferenceException($"{nameof(base.ParentMenu)} was null");
        
        SetChangeTaskIdFromBundle();
        
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
}