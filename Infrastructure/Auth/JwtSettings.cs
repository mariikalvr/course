namespace Infrastructure.Auth;
//Хранит все параметры, необходимые для работы JWT (JSON Web Token) аутентификации
public class JwtSettings
{
    public string Secret { get; set; }// Секретный ключ для подписи токена
    public int ExpiryMinutes { get; set; }// Время жизни токена в минутах
    public string Issuer { get; set; }// Издатель токена
    public string Audience { get; set; }// Для кого предназначен токен
}