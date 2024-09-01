namespace ProjectManagementSystem.Core.DomainEntities;

public class User
{
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
    /// Login of user
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Hashed password of user
    /// </summary>
    public string HashedPassword { get; set; } = null!;
}