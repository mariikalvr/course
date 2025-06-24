// using FluentValidation;

// public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
// {
//     public RegisterRequestValidator()
//     {
//         RuleFor(x => x.Email).NotEmpty().EmailAddress();
//         RuleFor(x => x.Password).MinimumLength(6);
//         RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
//         RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
//     }
// }