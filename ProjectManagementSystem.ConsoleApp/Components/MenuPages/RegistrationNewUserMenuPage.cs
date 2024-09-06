using System.ComponentModel.DataAnnotations;
using ProjectManagementSystem.Application.Services;
using ProjectManagementSystem.ConsoleApp.Extensions;
using ProjectManagementSystem.Core.DomainEntities;

namespace ProjectManagementSystem.ConsoleApp.Components.MenuPages;

public class RegistrationNewUserMenuPage : BaseMenuPage
{
    private readonly UserService _userService;
    private readonly UserAuthenticationService _userAuthenticationService;
    
    private User _newUser = new();

    public RegistrationNewUserMenuPage(
        UserService userService,
        UserAuthenticationService userAuthenticationService
        )
    {
        _userService = userService 
                       ?? throw new ArgumentNullException(nameof(userService));
        _userAuthenticationService = userAuthenticationService 
                                     ?? throw new ArgumentNullException(nameof(userAuthenticationService));
    }
    
    public override async Task OpenPageAsync()
    {
        if (base.ParentMenu is null)
            throw new NullReferenceException($"{nameof(base.ParentMenu)} was null");
        
        _newUser = new User()
        {
            Name = GetNameFromUser(),
            Surname = GetSurnameFromUser(),
            Patronymic = GetPatronymicFromUser(),
            Email = GetEmailFromUser(),
            Login = await GetLoginFromUserAsync(),
            HashedPassword = _userAuthenticationService.HashPassword(GetPasswordFromUser()),
            Role = GetUserRoleFromUser()
        };
        
        Console.Clear();
        if (await _userService.TryAddUserAsync(_newUser))
            Console.WriteLine("Пользователь добавлен!");
        else
            Console.WriteLine("Неизвестная ошибка!\n" +
                              "Пользователь не был добавлен!");
        Console.WriteLine("Для возвращения в меню нажмите enter");
        Console.ReadKey();
        
        await base.ParentMenu.ChangePageWithOpenAsync(typeof(MainSupervisorMenuPage), null);
    }

    public override void LeavePage()
    {
        Console.Clear();
    }

    private string GetNameFromUser()
    {
        Console.Clear();
        List<ValidationAttribute> validationAttributes = [new MinLengthAttribute(3)
        {
            ErrorMessage = "Имя должно быть длиннее или равно 3 символам"
        }];
        return ConsoleExtension.GetStringFromConsoleWithValidation(
            "Введите имя пользователя (мин. 3 символа):",
            "Имя некорректно!",
            validationAttributes
            );
    }
    
    private string GetSurnameFromUser()
    {
        Console.Clear();
        List<ValidationAttribute> validationAttributes = [new MinLengthAttribute(3)
        {
            ErrorMessage = "Фамилия должна быть длиннее или равна 3 символам"
        }];
        return ConsoleExtension.GetStringFromConsoleWithValidation(
            "Введите фамилию пользователя (мин. 3 символа):",
            "Фамилия некорректна!",
            validationAttributes
        );
    }

    private string GetPatronymicFromUser()
    {
        Console.Clear();
        Console.WriteLine("Введите отчество (необязательно):");
        return Console.ReadLine() ?? string.Empty;
    }

    private string GetEmailFromUser()
    {
        Console.Clear();
        List<ValidationAttribute> validationAttributes = [new EmailAddressAttribute()];
        return ConsoleExtension.GetStringFromConsoleWithValidation(
            "Введите email пользователя",
            "Email некорректен!",
            validationAttributes,
            false
            );
    }

    private async Task<string> GetLoginFromUserAsync()
    {
        Console.Clear();
        string login;
        while (true)
        {
            List<ValidationAttribute> validationAttributes = [new MinLengthAttribute(3)
            {
                ErrorMessage = "Логин должен быть длиннее или равен 3 символам"
            }];
            login = ConsoleExtension.GetStringFromConsoleWithValidation(
                "Введите логин пользователя",
                "Логин некорректен!",
                validationAttributes
            );
            if(await _userService.IsUniqueLoginAsync(login))
                break;
            
            Console.WriteLine("Логин занят! Попробуйте другой");
        }

        return login;
    }
    
    private string GetPasswordFromUser()
    {
        Console.Clear();
        List<ValidationAttribute> validationAttributes = [
            new RegularExpressionAttribute(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[A-Za-z\d]{8,}$")
            {
                ErrorMessage = "Пароль пользователя должен:\n" +
                               "1) Иметь минимум 8 символов\n" +
                               "2) Иметь минимум одну заглавную букву (A-Z)\n" +
                               "3) Иметь минимум одну строчную букву (a-z)\n" +
                               "4) Иметь минимум одну цифру (0-9)"
            },
        ];
        return ConsoleExtension.GetStringFromConsoleWithValidation(
            "Введите пароль пользователя:",
            "Пароль некорректен!",
            validationAttributes
        );
    }

    private UserRole GetUserRoleFromUser()
    {
        Console.Clear();
        PrintUserRoleChoice();
        return (UserRole)ConsoleExtension.GetOptionNumberFromConsole(
            PrintErrorOfChoiceUserRole,
            1,
            2
            );
    }

    private void PrintUserRoleChoice()
    {
        Console.Clear();
        Console.WriteLine("Выберите роль пользователя:\n" +
                          "1) Управляющий\n" +
                          "2) Обычный сотрудник");
    }

    private void PrintErrorOfChoiceUserRole()
    {
        Console.Clear();
        Console.WriteLine("Некорректный выбор роли!\n");
        Console.WriteLine("Выберите роль пользователя:\n" +
                          "1) Управляющий" +
                          "2) Обычный сотрудник");
    }
}