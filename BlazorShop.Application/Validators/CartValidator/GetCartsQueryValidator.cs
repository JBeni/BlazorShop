namespace BlazorShop.Application.Validators.CartValidator
{
    public class GetCartsCountQueryValidator : AbstractValidator<GetCartsCountQuery>
    {
        public GetCartsCountQueryValidator()
        {
            RuleFor(v => v.UserId).GreaterThan(0);
        }
    }
}
