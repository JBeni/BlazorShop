namespace BlazorShop.Application.Validators.CartValidator
{
    public class GetCartByIdQueryValidator : AbstractValidator<GetCartByIdQuery>
    {
        public GetCartByIdQueryValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(v => v.UserId).GreaterThan(0);
        }
    }
}
