namespace BlazorShop.Application.Validators.AccountValidator
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null");

            RuleFor(v => v.NewPassword)
                .MaximumLength(100).WithMessage("NewPassword maximum length exceeded")
                .NotEmpty().WithMessage("NewPassword must not be empty")
                .NotNull().WithMessage("NewPassword must not be null")
                .Equal(v => v.NewConfirmPassword).WithMessage("NewPassword must be equal with NewConfirmPassword");

            RuleFor(v => v.NewConfirmPassword)
                .MaximumLength(100).WithMessage("NewConfirmPassword maximum length exceeded")
                .NotEmpty().WithMessage("NewConfirmPassword must not be empty")
                .NotNull().WithMessage("NewConfirmPassword must not be null");
        }
    }
}
