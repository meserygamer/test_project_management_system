using System.ComponentModel.DataAnnotations;
using System.Globalization;

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
            number = default;
            return false;
        }
    }

    public static bool TryGetDatetime(out DateTime dateTime)
    {
        try
        {
            dateTime = DateTime.Parse(
                Console.ReadLine() ?? "",
                CultureInfo.GetCultureInfo("ru-RU")
                );
            return true;
        }
        catch (Exception e)
        {
            dateTime = default;
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

    public static string GetStringFromConsoleWithValidation(
        string messageForInput,
        string errorMessage,
        List<ValidationAttribute> validationAttributes,
        bool isPrintErrors = true
    )
    {
        string value;
        List<ValidationResult> validationResults;
        while (true)
        {
            Console.WriteLine(messageForInput);
            value = Console.ReadLine() ?? string.Empty;
            validationResults = new();
            if (Validator.TryValidateValue(value, new ValidationContext(value), validationResults, validationAttributes))
                break;
            
            Console.Clear();
            Console.WriteLine(errorMessage);
            if(isPrintErrors)
                foreach (var validationResult in validationResults) 
                    Console.WriteLine(validationResult.ErrorMessage);
        }
        return value;
    }
}