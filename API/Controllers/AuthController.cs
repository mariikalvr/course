// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// [ApiController]
// [Route("api/auth")]
// public class AuthController : ControllerBase
// {
//     private readonly IAuthService? _authService;

//     [HttpPost("register")]
//     public async Task<IActionResult> Register(RegisterRequest request)
//     {
//         var result = await _authService.RegisterAsync(request);
//         return Ok(result);
//     }

//     [HttpPost("login")]
//     public async Task<IActionResult> Login(LoginRequest request)
//     {
//         var token = await _authService.LoginAsync(request);
//         return Ok(new { Token = token });
//     }

//     [Authorize]
//     [HttpGet("profile")]
//     public IActionResult Profile()
//     {
//         var user = _authService.GetCurrentUser();
//         return Ok(user);
//     }
// }