namespace BlazorShop.Application.Validators.AppUserValidator
{
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        public GetUserByEmailQueryValidator()
        {
            RuleFor(v => v.Email).NotEmpty().NotNull();
        }
    }
}
