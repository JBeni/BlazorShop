namespace BlazorShop.Application.Validators.CartValidator
{
    public class DeleteAllCartsCommandValidator : AbstractValidator<DeleteAllCartsCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteAllCartsCommandValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
