namespace BlazorShop.Application.Validators.MusicValidator
{
    public class UpdateMusicCommandValidator : AbstractValidator<UpdateMusicCommand>
    {
        public UpdateMusicCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().NotNull();
            RuleFor(x => x.Description).NotEmpty().NotNull();
            RuleFor(x => x.Author).NotEmpty().NotNull();
            RuleFor(x => x.DateRelease).NotEmpty().NotNull();
            RuleFor(x => x.ImageName).NotEmpty().NotNull();
            RuleFor(x => x.ImagePath).NotEmpty().NotNull();
            RuleFor(x => x.AccessLevel).GreaterThan(0);
        }
    }
}
