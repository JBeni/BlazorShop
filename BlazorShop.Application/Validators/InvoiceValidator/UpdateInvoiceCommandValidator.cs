namespace BlazorShop.Application.Validators.InvoiceValidator
{
    public class UpdateInvoiceCommandValidator : AbstractValidator<UpdateInvoiceCommand>
    {
        public UpdateInvoiceCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(v => v.UserEmail).NotEmpty().NotNull();
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.AmountSubTotal).GreaterThan(0);
            RuleFor(v => v.AmountTotal).GreaterThan(0);
            RuleFor(v => v.Quantity).GreaterThan(0);
        }
    }
}
