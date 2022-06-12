namespace BlazorShop.Application.Validators.RoleValidator
{
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteRoleCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
