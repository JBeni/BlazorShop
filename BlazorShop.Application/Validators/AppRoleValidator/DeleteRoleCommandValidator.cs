namespace BlazorShop.Application.Validators.AppRoleValidator
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
