namespace BlazorShop.Application.Validators.CategoryValidator
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
