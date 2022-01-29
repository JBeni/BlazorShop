namespace BlazorShop.Application.Validators.InvoiceValidator
{
    public class GetInvoiceByIdQueryValidator : AbstractValidator<GetInvoiceByIdQuery>
    {
        public GetInvoiceByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
