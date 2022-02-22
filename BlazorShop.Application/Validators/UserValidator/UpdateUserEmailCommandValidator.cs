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
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(IsValidEmailAddress).WithMessage("The Email address is not valid");

            RuleFor(v => v.NewEmail)
                .MaximumLength(150).WithMessage("NewEmail maximum length exceeded")
                .NotEmpty().WithMessage("NewEmail must not be empty")
                .NotNull().WithMessage("NewEmail must not be null")
                .NotEqual(v => v.Email).WithMessage("NewEmail must not be equal with Email")
                .Must(IsValidEmailAddress).WithMessage("The NewEmail address is not valid");
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
