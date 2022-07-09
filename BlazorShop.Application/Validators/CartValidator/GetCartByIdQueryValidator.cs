// <copyright file="GetCartByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetCartByIdQueryValidator : AbstractValidator<GetCartByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetCartByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
