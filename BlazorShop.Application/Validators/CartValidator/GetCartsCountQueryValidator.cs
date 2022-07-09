// <copyright file="GetCartsQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetCartsQueryValidator : AbstractValidator<GetCartsQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetCartsQueryValidator()
        {
            _ = RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
