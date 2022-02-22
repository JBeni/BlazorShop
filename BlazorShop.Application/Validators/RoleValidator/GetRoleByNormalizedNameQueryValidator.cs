namespace BlazorShop.Application.Validators.RoleValidator
{
    public class GetRoleByNormalizedNameQueryValidator : AbstractValidator<GetRoleByNormalizedNameQuery>
    {
        public GetRoleByNormalizedNameQueryValidator()
        {
            RuleFor(v => v.NormalizedName)
                .MaximumLength(100).WithMessage("NormalizedName maximum length exceeded")
                .NotEmpty().WithMessage("NormalizedName must not be empty")
                .NotNull().WithMessage("NormalizedName must not be null");
        }
    }
}
