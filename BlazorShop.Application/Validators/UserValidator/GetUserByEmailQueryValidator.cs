namespace BlazorShop.Application.Validators.UserValidator
{
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailQueryValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(150).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(IsValidEmailAddress).WithMessage("The value is not a valid email address");
        }

        public bool IsValidEmailAddress(string emailAddress)
        {
            try
            {
                _ = new MailAddress(emailAddress);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
