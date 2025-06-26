using Domain.Enums;
using Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using projects.Domain.Entities;

namespace Application.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly JwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHasher<User> _passwordHasher;

    public AuthService(
        AppDbContext context,
        JwtTokenGenerator jwtTokenGenerator,
        IPasswordHasher<User> passwordHasher)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = passwordHasher;
    }

    public async Task<User> RegisterAsync(string email, string password, string firstName, string lastName, UserRole role = UserRole.Student)
    {
        if (await _context.Users.AnyAsync(u => u.Email == email))
        {
            throw new Exception("Email already exists");
        }

        var user = new User
        {
            Email = email,
            FirstName = firstName,
            LastName = lastName,
            Role = role,
            PasswordHash = string.Empty
        };

        // Хеширование пароля
        user.PasswordHash = _passwordHasher.HashPassword(user, password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        
        if (user == null || _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password) != PasswordVerificationResult.Success)
        {
            throw new Exception("Invalid credentials");
        }

        return _jwtTokenGenerator.GenerateToken(user);
    }

    public async Task<User> GetUserProfileAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }
}