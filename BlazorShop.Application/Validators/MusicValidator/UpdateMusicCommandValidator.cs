namespace BlazorShop.Application.Validators.MusicValidator
{
    public class UpdateMusicCommandValidator : AbstractValidator<UpdateMusicCommand>
    {
        public UpdateMusicCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Title)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Title must not be empty")
                .NotNull().WithMessage("Title must not be null");

            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Description must not be empty")
                .NotNull().WithMessage("Description must not be null");

            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author must not be empty")
                .NotNull().WithMessage("Author must not be null");

            RuleFor(x => x.DateRelease)
                .GreaterThan(new DateTime(1950, 1, 1)).WithMessage("Date must be greater than 1 January 1950")
                .NotEmpty().WithMessage("DateRelease must not be empty")
                .NotNull().WithMessage("DateRelease must not be null");

            RuleFor(x => x.ImageName)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("ImageName must not be empty")
                .NotNull().WithMessage("ImageName must not be null");

            RuleFor(x => x.ImagePath)
                .MaximumLength(200).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("ImagePath must not be empty")
                .NotNull().WithMessage("ImagePath must not be null");

            RuleFor(x => x.AccessLevel)
                .GreaterThan(0).WithMessage("AccessLevel must be greater than 0");
        }
    }
}
