using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using projects.Domain.Entities;

namespace Infrastructure.Auth;
//Сервис, который отвечает за создание (генерацию) JWT-токенов на основе переданных данных пользователя
public class JwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    // Конструктор с внедрением зависимостей
    public JwtTokenGenerator(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }

    public string GenerateToken(User user)
    {
        // 1. Создание обработчика токенов
        var tokenHandler = new JwtSecurityTokenHandler();
        
        // 2. Преобразование секрета в байты
        var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
        
        // 3. Формирование claims (утверждений) о пользователе
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(ClaimTypes.Role, user.Role.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        // 4. Описание токена
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature),
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience
        };

        // 5. Создание и подписание токена
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        // 6. Преобразование токена в строку
        return tokenHandler.WriteToken(token);
    }
}