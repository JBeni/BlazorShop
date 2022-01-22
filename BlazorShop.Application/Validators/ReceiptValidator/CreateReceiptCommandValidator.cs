namespace BlazorShop.Application.Validators.ReceiptValidator
{
    public class CreateReceiptCommandValidator : AbstractValidator<CreateReceiptCommand>
    {
        public CreateReceiptCommandValidator()
        {
            RuleFor(v => v.UserEmail).NotEmpty().NotNull();
            RuleFor(v => v.ReceiptDate).NotEmpty().NotNull();
            RuleFor(v => v.ReceiptName).NotEmpty().NotNull();
            RuleFor(v => v.ReceiptUrl).NotEmpty().NotNull();
        }
    }
}
