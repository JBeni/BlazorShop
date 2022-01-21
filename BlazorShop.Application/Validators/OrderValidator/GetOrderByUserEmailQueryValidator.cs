namespace BlazorShop.Application.Validators.OrderValidator
{
    public class GetOrderByUserEmailQueryValidator : AbstractValidator<GetOrderByUserEmailQuery>
    {
        public GetOrderByUserEmailQueryValidator()
        {
            RuleFor(v => v.UserEmail).NotEmpty().NotNull();
        }
    }
}
