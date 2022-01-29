namespace BlazorShop.Application.Validators.CartValidator
{
    public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
    {
        public UpdateCartCommandValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(v => v.ClotheId)
                .GreaterThan(0).WithMessage("ClotheId must be greater than 0");

            RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null");

            RuleFor(v => v.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(v => v.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");
        }
    }
}
