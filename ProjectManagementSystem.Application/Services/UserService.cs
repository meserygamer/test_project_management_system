using ProjectManagementSystem.Application.Interfaces;
using ProjectManagementSystem.Core.DomainEntities;
using ProjectManagementSystem.Core.RepositoryInterfaces;

namespace ProjectManagementSystem.Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
    }

    public async Task<bool> IsUniqueLoginAsync(string login)
        => (await _userRepository.GetUserByLoginAsync(login)) is null;

    public async Task<bool> TryAddUserAsync(User user)
        => await _userRepository.TryAddUserAsync(user);
}