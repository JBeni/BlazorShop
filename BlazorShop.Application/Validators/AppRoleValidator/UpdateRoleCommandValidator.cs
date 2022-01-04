namespace BlazorShop.Application.Validators.AppRoleValidator
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.Name).NotEmpty().NotNull();
        }
    }
}
