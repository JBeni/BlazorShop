namespace BlazorShop.Application.Validators.CategoryValidator
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.Name).NotEmpty().NotNull();
        }
    }
}
