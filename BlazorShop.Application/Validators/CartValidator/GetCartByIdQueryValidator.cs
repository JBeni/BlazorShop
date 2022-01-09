namespace BlazorShop.Application.Validators.CartValidator
{
    public class GetCartByIdQueryValidator : AbstractValidator<GetCartByIdQuery>
    {
        public GetCartByIdQueryValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
