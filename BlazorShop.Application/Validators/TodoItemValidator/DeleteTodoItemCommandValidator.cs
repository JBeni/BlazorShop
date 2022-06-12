namespace BlazorShop.Application.Validators.TodoItemValidator
{
    public  class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteTodoItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
