namespace BlazorShop.Application.Validators.InvoiceValidator
{
    public class DeleteInvoiceCommandValidator : AbstractValidator<DeleteInvoiceCommand>
    {
        public DeleteInvoiceCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
