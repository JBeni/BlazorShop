namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class GetSubscriberByIdQueryValidator : AbstractValidator<GetSubscriberByIdQuery>
    {
        public GetSubscriberByIdQueryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
