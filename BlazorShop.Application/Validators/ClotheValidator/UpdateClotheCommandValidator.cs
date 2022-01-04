namespace BlazorShop.Application.Validators.ClotheValidator
{
    public class UpdateClotheCommandValidator : AbstractValidator<UpdateClotheCommand>
    {
        public UpdateClotheCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.Price).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.Amount).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.ImageName).NotEmpty().NotNull();
            RuleFor(v => v.ImagePath).NotEmpty().NotNull();
        }
    }
}
