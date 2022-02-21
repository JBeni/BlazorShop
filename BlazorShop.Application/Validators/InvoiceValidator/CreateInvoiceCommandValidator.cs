namespace BlazorShop.Application.Validators.InvoiceValidator
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreateInvoiceCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("UserEmail maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");

            RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MustAsync(HaveUniqueName).WithMessage("The specified name already exists.");

            RuleFor(v => v.AmountSubTotal)
                .GreaterThan(0).WithMessage("AmountSubTotal must be greater than 0");

            RuleFor(v => v.AmountTotal)
                .GreaterThan(0).WithMessage("AmountTotal must be greater than 0");

            RuleFor(v => v.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0");
        }

        public async Task<bool> HaveUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Invoices
                .AllAsync(l => l.Name != name, cancellationToken);
        }
    }
}
