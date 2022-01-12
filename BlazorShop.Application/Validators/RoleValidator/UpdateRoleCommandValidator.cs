namespace BlazorShop.Application.Validators.RoleValidator
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(v => v.Name).NotEmpty().NotNull();
        }
    }
}
