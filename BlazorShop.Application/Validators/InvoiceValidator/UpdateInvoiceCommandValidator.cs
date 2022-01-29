namespace BlazorShop.Application.Validators.InvoiceValidator
{
    public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
    {
        public UpdateInvoiceCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");

            RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null");

            RuleFor(v => v.AmountSubTotal)
                .GreaterThan(0).WithMessage("AmountSubTotal must be greater than 0");

            RuleFor(v => v.AmountTotal)
                .GreaterThan(0).WithMessage("AmountTotal must be greater than 0");

            RuleFor(v => v.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }
    }
}
