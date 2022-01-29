namespace BlazorShop.Application.Validators.ReceiptValidator
{
    public class DeleteReceiptCommandValidator : AbstractValidator<DeleteReceiptCommand>
    {
        public DeleteReceiptCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
