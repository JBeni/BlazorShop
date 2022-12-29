// <copyright file="DeleteMusicCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.MusicValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteMusicCommand}"/>.
    /// </summary>
    public class DeleteMusicCommandValidator : AbstractValidator<DeleteMusicCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteMusicCommandValidator"/> class.
        /// </summary>
        public DeleteMusicCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
