namespace BlazorShop.Application.Validators.TodoListValidator
{
    public class GetTodoListByIdQueryValidator : AbstractValidator<GetTodoListByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetTodoListByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
