namespace BlazorShop.Application.Validators.ReceiptValidator
{
    public class GetReceiptsQueryValidator : AbstractValidator<GetReceiptsQuery>
    {
        public GetReceiptsQueryValidator()
        {
            RuleFor(v => v.UserEmail).NotEmpty().NotNull();
        }
    }
}
