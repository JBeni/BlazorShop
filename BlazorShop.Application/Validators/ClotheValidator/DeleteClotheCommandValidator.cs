namespace BlazorShop.Application.Validators.ClotheValidator
{
    public class DeleteClotheCommandValidator : AbstractValidator<DeleteClotheCommand>
    {
        public DeleteClotheCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.IsActive).NotEmpty().NotNull();
        }
    }
}
