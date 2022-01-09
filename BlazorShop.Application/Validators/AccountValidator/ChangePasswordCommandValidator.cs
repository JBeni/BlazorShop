namespace BlazorShop.Application.Validators.AccountValidator
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(v => v.UserId).GreaterThan(0);
            RuleFor(v => v.OldPassword).NotEmpty().NotNull().NotEqual(v => v.NewPassword);
            RuleFor(v => v.NewPassword).NotEmpty().NotNull().Equal(v => v.NewConfirmPassword);
            RuleFor(v => v.NewConfirmPassword).NotEmpty().NotNull();
        }
    }
}
