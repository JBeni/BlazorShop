namespace BlazorShop.Application.Validators.UserValidator
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(150).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null");

            RuleFor(v => v.FirstName)
                .MaximumLength(100).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("FirstName must not be empty")
                .NotNull().WithMessage("FirstName must not be null");

            RuleFor(v => v.LastName)
                .MaximumLength(100).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("LastName must not be empty")
                .NotNull().WithMessage("LastName must not be null");

            RuleFor(v => v.Role)
                .MaximumLength(25).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Role must not be empty")
                .NotNull().WithMessage("Role must not be null");
        }
    }
}
