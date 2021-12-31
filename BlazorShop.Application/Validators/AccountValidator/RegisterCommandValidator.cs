namespace BlazorShop.Application.Validators.AccountValidator
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(v => v.Email).NotEmpty().NotNull();
            RuleFor(v => v.FirstName).NotEmpty().NotNull();
            RuleFor(v => v.LastName).NotEmpty().NotNull();
            RuleFor(v => v.Password).NotEmpty().NotNull().Equal(v => v.ConfirmPassword);
            RuleFor(v => v.ConfirmPassword).NotEmpty().NotNull();
        }
    }
}
