namespace BlazorShop.Application.Validators.ProductPhotoValidator
{
    public class DeleteProductPhotoCommandValidator : AbstractValidator<DeleteProductPhotoCommand>
    {
        public DeleteProductPhotoCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
