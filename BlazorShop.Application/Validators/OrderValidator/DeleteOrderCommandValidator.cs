// <copyright file="DeleteOrderCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.OrderValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteOrderCommand}"/>.
    /// </summary>
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteOrderCommandValidator"/> class.
        /// </summary>
        public DeleteOrderCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
