namespace BlazorShop.Application.Validators.RoleValidator
{
    public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetRoleByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
