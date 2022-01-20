namespace BlazorShop.Application.Validators.MusicValidator
{
    public class CreateMusicCommandValidator : AbstractValidator<CreateMusicCommand>
    {
        public CreateMusicCommandValidator()
        {
            RuleFor(x => x.Id).Empty().Null();
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.Author).NotEmpty().NotNull();
            RuleFor(x => x.DateRelease).NotEmpty().NotNull();
            RuleFor(x => x.ImageName).NotEmpty().NotNull();
            RuleFor(x => x.ImagePath).NotEmpty().NotNull();
        }
    }
}
