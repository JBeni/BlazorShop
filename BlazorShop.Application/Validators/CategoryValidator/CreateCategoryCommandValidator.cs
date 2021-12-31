namespace BlazorShop.Application.Validators.CategoryValidator
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty().NotNull();
        }
    }
}
