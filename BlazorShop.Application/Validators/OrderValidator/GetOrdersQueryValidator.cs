namespace BlazorShop.Application.Validators.OrderValidator
{
    public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
    {
        public GetOrdersQueryValidator()
        {
            RuleFor(v => v.UserEmail).NotEmpty().NotNull();
        }
    }
}
