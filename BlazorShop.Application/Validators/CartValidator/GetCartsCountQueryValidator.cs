// <copyright file="GetCartsCountQueryValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetCartsCountQuery}"/>.
    /// </summary>
    public class GetCartsCountQueryValidator : AbstractValidator<GetCartsCountQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartsCountQueryValidator"/> class.
        /// </summary>
        public GetCartsCountQueryValidator()
        {
            this.RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
