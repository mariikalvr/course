using Microsoft.AspNetCore.Identity;
using projects.Domain.Entities;

namespace Infrastructure.Auth;

public class PasswordHasher : IPasswordHasher<User>
{
    private readonly int _workFactor;

    public PasswordHasher(int workFactor = 12)
    {
        _workFactor = workFactor;
    }

    public string HashPassword(User user, string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, _workFactor);
    }

    public PasswordVerificationResult VerifyHashedPassword(
        User user, 
        string hashedPassword, 
        string providedPassword)
    {
        try
        {
            var isValid = BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
            return isValid 
                ? PasswordVerificationResult.Success
                : PasswordVerificationResult.Failed;
        }
        catch
        {
            return PasswordVerificationResult.Failed;
        }
    }

    
}