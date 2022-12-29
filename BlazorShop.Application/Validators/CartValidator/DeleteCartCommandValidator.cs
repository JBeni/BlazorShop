// <copyright file="DeleteCartCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteCartCommand}"/>.
    /// </summary>
    public class DeleteCartCommandValidator : AbstractValidator<DeleteCartCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCartCommandValidator"/> class.
        /// </summary>
        public DeleteCartCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
