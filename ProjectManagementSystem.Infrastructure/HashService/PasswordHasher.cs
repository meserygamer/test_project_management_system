using ProjectManagementSystem.Application.Interfaces;

namespace ProjectManagementSystem.Infrastructure.HashService;

public class PasswordHasher : IPasswordHasher
{
    public string HashPassword(string password)
        => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    
    public bool VerifyPassword(string? password, string? hashedPassword)
    {
        if(password is null || hashedPassword is null)
            return false;
        return BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
    }
}