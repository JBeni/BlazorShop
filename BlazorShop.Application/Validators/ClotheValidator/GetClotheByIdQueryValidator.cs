namespace BlazorShop.Application.Validators.ClotheValidator
{
    public class GetClotheByIdQueryValidator : AbstractValidator<GetClotheByIdQuery>
    {
        public GetClotheByIdQueryValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
