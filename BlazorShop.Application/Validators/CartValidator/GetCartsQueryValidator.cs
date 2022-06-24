// <copyright file="GetCartsCountQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetCartsCountQueryValidator : AbstractValidator<GetCartsCountQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetCartsCountQueryValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
