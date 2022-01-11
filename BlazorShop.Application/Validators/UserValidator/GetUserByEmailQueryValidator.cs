namespace BlazorShop.Application.Validators.UserValidator
{
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailQueryValidator()
        {
            RuleFor(v => v.Email).NotEmpty().NotNull();
        }
    }
}
