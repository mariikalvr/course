// // RegisterRequest.cs
// public record RegisterRequest(
//     [Required, EmailAddress] string Email,
//     [Required, MinLength(6)] string Password,
//     [Required] string FirstName,
//     [Required] string LastName);

// // LoginRequest.cs
// public record LoginRequest(
//     [Required, EmailAddress] string Email,
//     [Required] string Password);

// // CourseCreateRequest.cs
// public record CourseCreateRequest(
//     [Required, StringLength(100)] string Title,
//     [StringLength(500)] string Description);