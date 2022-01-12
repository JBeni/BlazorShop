namespace BlazorShop.Application.Validators.CartValidator
{
    public class DeleteCartCommandValidator : AbstractValidator<DeleteCartCommand>
    {
        public DeleteCartCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(v => v.UserId).GreaterThan(0);
        }
    }
}
