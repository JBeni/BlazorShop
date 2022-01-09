namespace BlazorShop.Application.Validators.CartValidator
{
    public class DeleteCartCommandValidator : AbstractValidator<DeleteCartCommand>
    {
        public DeleteCartCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
