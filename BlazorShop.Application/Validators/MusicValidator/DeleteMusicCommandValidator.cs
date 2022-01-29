namespace BlazorShop.Application.Validators.MusicValidator
{
    public class DeleteMusicCommandValidator : AbstractValidator<DeleteMusicCommand>
    {
        public DeleteMusicCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
