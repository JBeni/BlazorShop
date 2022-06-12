namespace BlazorShop.Application.Validators.CartValidator
{
    public class GetCartsCountQueryValidator : AbstractValidator<GetCartsCountQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetCartsCountQueryValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
