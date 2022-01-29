namespace BlazorShop.Application.Validators.UserValidator
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

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
