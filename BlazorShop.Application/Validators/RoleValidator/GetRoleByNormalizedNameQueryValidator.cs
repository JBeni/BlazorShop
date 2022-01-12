namespace BlazorShop.Application.Validators.RoleValidator
{
    public class GetRoleByNormalizedNameQueryValidator : AbstractValidator<GetRoleByNormalizedNameQuery>
    {
        public GetRoleByNormalizedNameQueryValidator()
        {
            RuleFor(v => v.NormalizedName).NotEmpty().NotNull();
        }
    }
}
