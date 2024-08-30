namespace ProjectManagementSystem.Core.DomainEntities;

public class UserAuthenticationData
{
    /// <summary>
    /// Login of user
    /// </summary>
    public string Login { get; set; } = null!;

    /// <summary>
    /// Hashed password of user
    /// </summary>
    public string HashedPassword { get; set; } = null!;

    /// <summary>
    /// The owner of the authentication data
    /// </summary>
    public User User { get; set; } = null!;
}