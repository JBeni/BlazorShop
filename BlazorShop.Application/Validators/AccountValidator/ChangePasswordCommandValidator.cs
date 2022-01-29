namespace BlazorShop.Application.Validators.AccountValidator
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            _ = RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            _ = RuleFor(v => v.OldPassword)
                .NotEmpty().WithMessage("OldPassword must not be empty")
                .NotNull().WithMessage("OldPassword must not be null")
                .NotEqual(v => v.NewPassword).WithMessage("OldPassword must not be equal with NewPassword");

            _ = RuleFor(v => v.NewPassword)
                .NotEmpty().WithMessage("NewPassword must not be empty")
                .NotNull().WithMessage("NewPassword must not be null")
                .Equal(v => v.ConfirmNewPassword).WithMessage("NewPassword must be equal with ConfirmNewPassword");

            _ = RuleFor(v => v.ConfirmNewPassword)
                .NotEmpty().WithMessage("ConfirmNewPassword must not be empty")
                .NotNull().WithMessage("ConfirmNewPassword must not be null");
        }
    }
}
