namespace BlazorShop.Application.Validators.InvoiceValidator
{
    public class DeleteInvoiceCommandValidator : AbstractValidator<DeleteInvoiceCommand>
    {
        public DeleteInvoiceCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
