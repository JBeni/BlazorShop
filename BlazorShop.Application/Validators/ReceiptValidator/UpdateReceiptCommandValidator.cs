namespace BlazorShop.Application.Validators.ReceiptValidator
{
    public class UpdateReceiptCommandValidator : AbstractValidator<UpdateReceiptCommand>
    {
        public UpdateReceiptCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(v => v.ReceiptDate).NotEmpty().NotNull();
            RuleFor(v => v.ReceiptName).NotEmpty().NotNull();
            RuleFor(v => v.ReceiptUrl).NotEmpty().NotNull();
        }
    }
}
