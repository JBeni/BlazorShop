namespace BlazorShop.Application.Validators.UserValidator
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteUserCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
