// <copyright file="DeleteClotheCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClotheValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteClotheCommandValidator : AbstractValidator<DeleteClotheCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteClotheCommandValidator()
        {
            _ = RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
