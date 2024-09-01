using ProjectManagementSystem.Application.Interfaces;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;

namespace ProjectManagementSystem.Application.Services;

public class UserAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    
    public UserAuthenticationService(IUserRepository userRepository,
        IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
    }

    public async Task<User?> AuthenticateUserAsync(string login, string password)
    {
        User? intendedUser = await _userRepository.GetUserByLoginAsync(login);
        string? intendedUserHashedPassword = intendedUser?.HashedPassword;
        return _passwordHasher.VerifyPassword(password, intendedUserHashedPassword) ? intendedUser : null;
    }
}