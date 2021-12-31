namespace BlazorShop.Application.Validators.ProductPhotoValidator
{
    public class UpdateProductPhotoCommandValidator : AbstractValidator<UpdateProductPhotoCommand>
    {
        public UpdateProductPhotoCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(v => v.Image).NotEmpty().NotNull();
        }
    }
}
