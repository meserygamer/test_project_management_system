using System.Text;

namespace ProjectManagementSystem.Core.DomainEntities;

public class User
{
    /// <summary>
    /// Number of user into system
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the user
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Surname of the user
    /// </summary>
    public string Surname { get; set; } = null!;

    /// <summary>
    /// Patronymic of the user
    /// </summary>
    public string Patronymic { get; set; } = null!;

    /// <summary>
    /// Email address of the user
    /// </summary>
    public string Email { get; set; } = null!;

    /// <summary>
    /// User role in system
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// Login of user
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Hashed password of user
    /// </summary>
    public string HashedPassword { get; set; } = null!;

    public string FullName => $"{Surname} {Name} {Patronymic}";
    
    public string UserInfo 
        => new StringBuilder()
            .Append($"Номер пользователя: {Id}\n")
            .Append($"ФИО: {FullName}\n")
            .Append($"Email: {Email}\n")
            .Append($"Роль: {Role}\n")
            .Append($"Login: {Login}\n")
            .ToString();
}