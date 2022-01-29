namespace BlazorShop.Application.Validators.UserValidator
{
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailQueryValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(150).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null");
        }
    }
}
