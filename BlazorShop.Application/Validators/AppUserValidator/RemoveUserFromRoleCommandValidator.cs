namespace BlazorShop.Application.Validators.AppUserValidator
{
    public class RemoveUserFromRoleCommandValidator : AbstractValidator<RemoveUserFromRoleCommand>
    {
        public RemoveUserFromRoleCommandValidator()
        {
            RuleFor(v => v.UserId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.RoleId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
