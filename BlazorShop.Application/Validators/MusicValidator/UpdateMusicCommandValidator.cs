// <copyright file="UpdateMusicCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.MusicValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateMusicCommand}"/>.
    /// </summary>
    public class UpdateMusicCommandValidator : AbstractValidator<UpdateMusicCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateMusicCommandValidator"/> class.
        /// </summary>
        /// <param name="context">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        public UpdateMusicCommandValidator(IApplicationDbContext context)
        {
            this.Context = context;

            this.RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            this.RuleFor(x => x.Title)
                .MaximumLength(200).WithMessage("Title maximum length exceeded")
                .NotEmpty().WithMessage("Title must not be empty")
                .NotNull().WithMessage("Title must not be null")
                .MustAsync(this.HaveUniqueTitle).WithMessage("The specified title already exists.");

            this.RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description maximum length exceeded")
                .NotEmpty().WithMessage("Description must not be empty")
                .NotNull().WithMessage("Description must not be null");

            this.RuleFor(x => x.Author)
                .MaximumLength(200).WithMessage("Author maximum length exceeded")
                .NotEmpty().WithMessage("Author must not be empty")
                .NotNull().WithMessage("Author must not be null");

            this.RuleFor(x => x.DateRelease)
                .GreaterThan(new DateTime(1950, 1, 1)).WithMessage("DateRelease must be greater than 1 January 1950")
                .NotEmpty().WithMessage("DateRelease must not be empty")
                .NotNull().WithMessage("DateRelease must not be null");

            this.RuleFor(x => x.ImageName)
                .MaximumLength(200).WithMessage("ImageName maximum length exceeded")
                .NotEmpty().WithMessage("ImageName must not be empty")
                .NotNull().WithMessage("ImageName must not be null");

            this.RuleFor(x => x.ImagePath)
                .MaximumLength(200).WithMessage("ImagePath maximum length exceeded")
                .NotEmpty().WithMessage("ImagePath must not be empty")
                .NotNull().WithMessage("ImagePath must not be null");

            this.RuleFor(x => x.AccessLevel)
                .GreaterThan(0).WithMessage("AccessLevel must be greater than 0");
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext Context { get; }

        /// <summary>
        /// Gets a value indicating whether the music has an unique title or not.
        /// </summary>
        /// <param name="title">The title of the music.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A boolean value.</returns>
        public async Task<bool> HaveUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await this.Context.Musics
                .TagWith(nameof(this.HaveUniqueTitle))
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}
