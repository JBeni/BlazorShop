namespace BlazorShop.Application.Validators.AppRoleValidator
{
    public class GetRoleByNormalizedNameQueryValidator : AbstractValidator<GetRoleByNormalizedNameQuery>
    {
        public GetRoleByNormalizedNameQueryValidator()
        {
            RuleFor(v => v.NormalizedName).NotEmpty().NotNull();
        }
    }
}
