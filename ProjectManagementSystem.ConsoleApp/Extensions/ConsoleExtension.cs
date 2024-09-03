namespace ProjectManagementSystem.ConsoleApp.Extensions;

public static class ConsoleExtension
{
    public static bool TryGetInt32(out int number)
    {
        try
        {
            number = Convert.ToInt32(Console.ReadLine());
            return true;
        }
        catch (Exception e)
        {
            number = 0;
            return false;
        }
    }
    
    public static int GetOptionNumberFromConsole(
        Action inputErrorHandler,
        int minInclusive,
        int maxInclusive)
    {
        int optionNumber = 0;
        while (true)
        {
            if (ConsoleExtension.TryGetInt32(out optionNumber)
                && optionNumber.IsInRange(minInclusive, maxInclusive)) 
                break;
            
            if(inputErrorHandler is not null) 
                inputErrorHandler.Invoke();
        }

        return optionNumber;
    }
    
    public static async Task<int?> GetOptionNumberFromConsoleWithDenyAsync(
        Func<Task> inputErrorHandler,
        string[] denyStrings,
        int minInclusive,
        int maxInclusive)
    {
        int optionNumber = 0;
        while (true)
        {
            string? userChoice = Console.ReadLine();
            if (userChoice.IsInList(denyStrings))
                return null;
            
            if (userChoice.TryConvertToInt32(out optionNumber) 
                && optionNumber.IsInRange(minInclusive, maxInclusive))
                break;
            
            if(inputErrorHandler is not null)
                await inputErrorHandler.Invoke();
        }

        return optionNumber;
    }
}