// <copyright file="GetCartsQueryValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetCartsQuery}"/>.
    /// </summary>
    public class GetCartsQueryValidator : AbstractValidator<GetCartsQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartsQueryValidator"/> class.
        /// </summary>
        public GetCartsQueryValidator()
        {
            _ = this.RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
