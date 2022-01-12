namespace BlazorShop.Application.Validators.RoleValidator
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().NotNull();
        }
    }
}
