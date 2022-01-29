namespace BlazorShop.Application.Validators.CartValidator
{
    public class GetCartsQueryValidator : AbstractValidator<GetCartsQuery>
    {
        public GetCartsQueryValidator()
        {
            _ = RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
