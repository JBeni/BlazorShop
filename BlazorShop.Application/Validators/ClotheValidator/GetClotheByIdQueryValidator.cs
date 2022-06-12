namespace BlazorShop.Application.Validators.ClotheValidator
{
    public class GetClotheByIdQueryValidator : AbstractValidator<GetClotheByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetClotheByIdQueryValidator()
        {
            _ = RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
