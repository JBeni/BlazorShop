namespace BlazorShop.Application.Validators.CartValidator
{
    public class GetCartsQueryValidator : AbstractValidator<GetCartsQuery>
    {
        public GetCartsQueryValidator()
        {
            RuleFor(v => v.UserId).GreaterThan(0);
        }
    }
}
