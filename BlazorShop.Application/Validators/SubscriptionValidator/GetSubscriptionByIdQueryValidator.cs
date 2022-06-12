namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    public class GetSubscriptionByIdQueryValidator : AbstractValidator<GetSubscriptionByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetSubscriptionByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
