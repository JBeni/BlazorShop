namespace BlazorShop.Application.Validators.MusicValidator
{
    public class GetMusicByIdQueryValidator : AbstractValidator<GetMusicByIdQuery>
    {
        public GetMusicByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
