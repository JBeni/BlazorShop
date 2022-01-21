namespace BlazorShop.Application.Validators.ReceiptValidator
{
    public class GetReceiptByIdQueryValidator : AbstractValidator<GetReceiptByIdQuery>
    {
        public GetReceiptByIdQueryValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
