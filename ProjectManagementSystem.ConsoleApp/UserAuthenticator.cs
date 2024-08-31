using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp;

public class UserAuthenticator
{
    private const ConsoleColor ColorOfGreetingText = ConsoleColor.Green;
    private const ConsoleColor ColorOfRegularText = ConsoleColor.White;
    private const ConsoleColor ColorOfFailureMessage = ConsoleColor.Red;
    
    private readonly UserAuthenticationService _userAuthenticationService;
    
    public UserAuthenticator(UserAuthenticationService userAuthenticationService)
    {
        _userAuthenticationService = userAuthenticationService;
    }

    public User AuthenticateUser()
    {
        PrintGreeting();
        return GetUserFromConsole();
    }

    private void PrintGreeting()
    {
        ConsoleColor consoleTextColorBefore = Console.ForegroundColor;
        Console.ForegroundColor = ColorOfGreetingText;
        Console.Clear();
        Console.WriteLine("Приветствуем в системе управления проектом!");
        Console.ForegroundColor = ColorOfRegularText;
        Console.WriteLine("Для дальнейшего использования системы необходимо осуществить вход");
        Console.ForegroundColor = consoleTextColorBefore;
    }

    private string GetLoginFromUser()
    {
        Console.WriteLine("Введите логин:");
        return Console.ReadLine() ?? "";
    }

    private string GetPasswordFromUser()
    {
        Console.WriteLine("Введите пароль:");
        return Console.ReadLine() ?? "";
    }

    private User GetUserFromConsole()
    {
        User? user;
        do
        {
            string login = GetLoginFromUser();
            string password = GetPasswordFromUser();

            user = _userAuthenticationService.AuthenticateUser(login, password);
            if (user is null)
            {
                Console.Clear();
                PrintAuthenticateFailureMessage();
            }
        } while (user is null);
        
        return user;
    }

    private void PrintAuthenticateFailureMessage()
    {
        ConsoleColor consoleTextColorBefore = Console.ForegroundColor;
        Console.ForegroundColor = ColorOfFailureMessage;
        Console.WriteLine("Неверный логин или пароль!");
        Console.ForegroundColor = consoleTextColorBefore;
    }
}