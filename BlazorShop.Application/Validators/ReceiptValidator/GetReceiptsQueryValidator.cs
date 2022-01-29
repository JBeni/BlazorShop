namespace BlazorShop.Application.Validators.ReceiptValidator
{
    public class GetReceiptsQueryValidator : AbstractValidator<GetReceiptsQuery>
    {
        public GetReceiptsQueryValidator()
        {
            RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");
        }
    }
}
