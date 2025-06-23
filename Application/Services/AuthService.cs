// using projects.Domain.Entities;

// public class AuthService : IAuthService
// {
//     private readonly AppDbContext _context;
//     private readonly IConfiguration _config;
//     private readonly IPasswordHasher _passwordHasher;

//     public AuthService(AppDbContext context, IConfiguration config, IPasswordHasher passwordHasher)
//     {
//         _context = context;
//         _config = config;
//         _passwordHasher = passwordHasher;
//     }

//     public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
//     {
//         // Проверка существования пользователя
//         if (await _context.Users.AnyAsync(u => u.Email == request.Email))
//             throw new BadRequestException("Email already exists");

//         var user = new User
//         {
//             Email = request.Email,
//             PasswordHash = _passwordHasher.HashPassword(request.Password),
//             Role = "Student" // По умолчанию
//         };

//         _context.Users.Add(user);
//         await _context.SaveChangesAsync();

//         return new AuthResponse(user.Id, user.Email, user.Role);
//     }

//     public async Task<string> LoginAsync(LoginRequest request)
//     {
//         var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email)
//             ?? throw new NotFoundException("User not found");

//         if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
//             throw new BadRequestException("Invalid credentials");

//         return GenerateJwtToken(user);
//     }

//     private string GenerateJwtToken(User user)
//     {
//         var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
//         var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

//         var claims = new[]
//         {
//             new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
//             new Claim(ClaimTypes.Email, user.Email),
//             new Claim(ClaimTypes.Role, user.Role)
//         };

//         var token = new JwtSecurityToken(
//             _config["Jwt:Issuer"],
//             _config["Jwt:Audience"],
//             claims,
//             expires: DateTime.Now.AddDays(7),
//             signingCredentials: credentials);

//         return new JwtSecurityTokenHandler().WriteToken(token);
//     }
// }