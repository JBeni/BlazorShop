// <copyright file="GetClotheByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClotheValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetClotheByIdQueryValidator : AbstractValidator<GetClotheByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetClotheByIdQueryValidator()
        {
            _ = RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
