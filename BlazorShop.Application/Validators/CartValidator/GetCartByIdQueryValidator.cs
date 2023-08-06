﻿// <copyright file="GetCartByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetCartByIdQuery}"/>.
    /// </summary>
    public class GetCartByIdQueryValidator : AbstractValidator<GetCartByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetCartByIdQueryValidator"/> class.
        /// </summary>
        public GetCartByIdQueryValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            this.RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
