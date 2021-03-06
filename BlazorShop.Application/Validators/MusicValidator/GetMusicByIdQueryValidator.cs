// <copyright file="GetMusicByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.MusicValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetMusicByIdQueryValidator : AbstractValidator<GetMusicByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetMusicByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
