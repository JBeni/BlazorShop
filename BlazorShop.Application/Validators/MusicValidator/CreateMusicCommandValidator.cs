namespace BlazorShop.Application.Validators.MusicValidator
{
    public class CreateMusicCommandValidator : AbstractValidator<CreateMusicCommand>
    {
        public CreateMusicCommandValidator()
        {
            RuleFor(x => x.Id).Equal(0);
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.Author).NotEmpty().NotNull();
            RuleFor(x => x.DateRelease).NotEmpty().NotNull();
            RuleFor(x => x.ImageName).NotEmpty().NotNull();
            RuleFor(x => x.ImagePath).NotEmpty().NotNull();
        }
    }
}
