namespace BlazorShop.Application.Validators.UserValidator
{
    public class UpdateUserEmailCommandValidator : AbstractValidator<UpdateUserEmailCommand>
    {
        public UpdateUserEmailCommandValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(v => v.Email)
                .MaximumLength(150).WithMessage("Email maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .NotEqual(v => v.NewEmail).WithMessage("Email must not be equal with NewEmail");

            RuleFor(v => v.NewEmail)
                .MaximumLength(150).WithMessage("NewEmail maximum length exceeded")
                .NotEmpty().WithMessage("NewEmail must not be empty")
                .NotNull().WithMessage("NewEmail must not be null");
        }
    }
}
