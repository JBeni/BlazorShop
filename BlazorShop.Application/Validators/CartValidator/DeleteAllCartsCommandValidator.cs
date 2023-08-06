// <copyright file="DeleteAllCartsCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteAllCartsCommand}"/>.
    /// </summary>
    public class DeleteAllCartsCommandValidator : AbstractValidator<DeleteAllCartsCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteAllCartsCommandValidator"/> class.
        /// </summary>
        public DeleteAllCartsCommandValidator()
        {
            this.RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
