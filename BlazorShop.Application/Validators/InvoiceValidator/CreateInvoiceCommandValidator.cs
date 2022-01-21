namespace BlazorShop.Application.Validators.InvoiceValidator
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(v => v.UserEmail).NotEmpty().NotNull();
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.AmountSubTotal).GreaterThan(0);
            RuleFor(v => v.AmountTotal).GreaterThan(0);
            RuleFor(v => v.Quantity).GreaterThan(0);
        }
    }
}
