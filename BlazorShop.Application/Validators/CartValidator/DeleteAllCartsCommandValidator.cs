namespace BlazorShop.Application.Validators.CartValidator
{
    public class DeleteAllCartsCommandValidator : AbstractValidator<DeleteAllCartsCommand>
    {
        public DeleteAllCartsCommandValidator()
        {
            RuleFor(v => v.UserId).GreaterThan(0);
        }
    }
}
