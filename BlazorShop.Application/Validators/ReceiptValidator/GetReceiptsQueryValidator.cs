namespace BlazorShop.Application.Validators.ReceiptValidator
{
    public class GetReceiptsQueryValidator : AbstractValidator<GetReceiptsQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetReceiptsQueryValidator()
        {
            RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("UserEmail maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");
        }
    }
}
