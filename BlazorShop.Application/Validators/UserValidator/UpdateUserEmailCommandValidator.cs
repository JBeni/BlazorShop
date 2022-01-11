namespace BlazorShop.Application.Validators.UserValidator
{
    public class UpdateUserEmailCommandValidator : AbstractValidator<UpdateUserEmailCommand>
    {
        public UpdateUserEmailCommandValidator()
        {
            RuleFor(v => v.UserId).GreaterThan(0);
            RuleFor(v => v.Email).NotEmpty().NotNull().NotEqual(v => v.NewEmail);
            RuleFor(v => v.NewEmail).NotEmpty().NotNull();
        }
    }
}
