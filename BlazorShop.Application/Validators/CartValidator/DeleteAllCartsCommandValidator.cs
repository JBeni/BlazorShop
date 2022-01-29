namespace BlazorShop.Application.Validators.CartValidator
{
    public class DeleteAllCartsCommandValidator : AbstractValidator<DeleteAllCartsCommand>
    {
        public DeleteAllCartsCommandValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
