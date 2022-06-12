namespace BlazorShop.Application.Validators.TodoListValidator
{
    public class DeleteTodoListCommandValidator : AbstractValidator<DeleteTodoListCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteTodoListCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
