namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class GetUserSubscribersQueryValidator : AbstractValidator<GetUserSubscribersQuery>
    {
        public GetUserSubscribersQueryValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0);
        }
    }
}
