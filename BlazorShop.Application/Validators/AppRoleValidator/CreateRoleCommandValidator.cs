namespace BlazorShop.Application.Validators.AppRoleValidator
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.NormalizedName).NotEmpty().NotNull();
        }
    }
}
