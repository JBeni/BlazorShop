namespace BlazorShop.Application.Validators.ClotheValidator
{
    public class UpdateClotheCommandValidator : AbstractValidator<UpdateClotheCommand>
    {
        public UpdateClotheCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.Description).NotEmpty().NotNull();
            RuleFor(v => v.Price).GreaterThan(0);
            RuleFor(v => v.Amount).GreaterThan(0);
            RuleFor(v => v.ImageName).NotEmpty().NotNull();
            RuleFor(v => v.ImagePath).NotEmpty().NotNull();
        }
    }
}
