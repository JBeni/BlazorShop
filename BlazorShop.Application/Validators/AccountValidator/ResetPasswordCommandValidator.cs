namespace BlazorShop.Application.Validators.AccountValidator
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().NotNull();
            RuleFor(v => v.TokenReset).NotEmpty().NotNull();
            RuleFor(v => v.NewPassword).NotEmpty().NotNull().Equal(v => v.NewConfirmPassword);
            RuleFor(v => v.NewConfirmPassword).NotEmpty().NotNull();
        }
    }
}
