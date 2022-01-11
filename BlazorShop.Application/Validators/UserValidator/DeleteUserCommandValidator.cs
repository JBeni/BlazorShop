namespace BlazorShop.Application.Validators.UserValidator
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}
