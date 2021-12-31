namespace BlazorShop.Application.Validators.ProductPhotoValidator
{
    public class CreateProductPhotoCommandValidator : AbstractValidator<CreateProductPhotoCommand>
    {
        public CreateProductPhotoCommandValidator()
        {
            RuleFor(v => v.Image).NotEmpty().NotNull();
        }
    }
}
