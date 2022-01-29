namespace BlazorShop.Application.Validators.ClotheValidator
{
    public class UpdateClotheCommandValidator : AbstractValidator<UpdateClotheCommand>
    {
        public UpdateClotheCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null");

            RuleFor(v => v.Description)
                .MaximumLength(1000).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Description must not be empty")
                .NotNull().WithMessage("Description must not be null");

            RuleFor(v => v.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(v => v.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");

            RuleFor(v => v.ImageName)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("ImageName must not be empty")
                .NotNull().WithMessage("ImageName must not be null");

            RuleFor(v => v.ImagePath)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("ImagePath must not be empty")
                .NotNull().WithMessage("ImagePath must not be null");
        }
    }
}
