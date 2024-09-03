using ProjectManagementSystem.ConsoleApp.Extensions;

namespace ProjectManagementSystem.ConsoleApp.Components.MenuPages;

public class MainSupervisorMenuPage : BaseMenuPage
{
    public Dictionary<int, Type> NextPages = new ()
    {
        { 1, typeof(RegistrationNewUserMenuPage) },
        { 2, typeof(CreateNewProjectTaskMenuPage) },
        { 3, typeof(AssignProjectTaskToUserMenuPage) }
    };
    
    public override async Task OpenPageAsync()
    {
        if(base.User is null)
            throw new NullReferenceException($"{nameof(base.User)} was null");
        
        if (base.ParentMenu is null)
            throw new NullReferenceException($"{nameof(base.ParentMenu)} was null");

        PrintSupervisorOptionsMenuIntoConsole();
        int optionNumber = ConsoleExtension.GetOptionNumberFromConsole(
            PrintInputOptionNumberError,
            1,
            3
            );
        if (!NextPages.TryGetValue(optionNumber, out Type? nextPage))
            throw new SystemException("There is no page with this number");
        
        await base.ParentMenu.ChangePageWithOpenAsync(nextPage, null);
    }

    public override void LeavePage()
    {
        Console.Clear();
    }

    private void PrintSupervisorOptionsMenuIntoConsole()
    {
        Console.Clear();
        Console.WriteLine($"Здравствуйте управляющий, {base.User!.FullName}\n");
        PrintSupervisorOptionsIntoConsole();
    }

    private void PrintInputOptionNumberError()
    {
        Console.Clear();
        Console.WriteLine($"Здравствуйте управляющий, {base.User!.FullName}\n");
        Console.WriteLine("Некорректный номер функции управляющего! Повторите ввод");
        PrintSupervisorOptionsIntoConsole();
    }

    private void PrintSupervisorOptionsIntoConsole()
    {
        Console.WriteLine($"Ваши возможности (выбор осуществляется вводом номера):\n" +
                          $"1) Регистрация сотрудника\n" +
                          $"2) Создание задачи\n" +
                          $"3) Назначение задачи\n");
    }
    
    /*
    private int GetOptionNumberFromConsole(Action inputErrorHandler)
    {
        int optionNumber = 0;
        while (true)
        {
            if (ConsoleExtension.TryGetInt32(out optionNumber)
                && optionNumber.IsInRange(1, 3)) 
                break;
            
            if(inputErrorHandler is not null) 
                inputErrorHandler.Invoke();
        }

        return optionNumber;
    }
    */
    
}