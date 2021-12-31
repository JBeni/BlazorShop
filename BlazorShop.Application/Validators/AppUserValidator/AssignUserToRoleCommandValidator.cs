namespace BlazorShop.Application.Validators.AppUserValidator
{
    public class AssignUserToRoleCommandValidator : AbstractValidator<AssignUserToRoleCommand>
    {
        public AssignUserToRoleCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.RoleId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
