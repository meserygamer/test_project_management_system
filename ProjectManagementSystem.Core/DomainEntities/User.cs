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
    /// Authentication data of the user
    /// </summary>
    public UserAuthenticationData AuthenticationData { get; set; } = null!;
}