// <copyright file="GetMusicByIdQueryValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.MusicValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetMusicByIdQuery}"/>.
    /// </summary>
    public class GetMusicByIdQueryValidator : AbstractValidator<GetMusicByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMusicByIdQueryValidator"/> class.
        /// </summary>
        public GetMusicByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
