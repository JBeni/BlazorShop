namespace BlazorShop.Application.Validators.AccountValidator
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().NotNull();
            RuleFor(v => v.Password).NotEmpty().NotNull();
        }
    }
}
