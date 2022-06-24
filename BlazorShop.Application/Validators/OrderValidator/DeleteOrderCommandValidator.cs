// <copyright file="DeleteOrderCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.OrderValidator
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteOrderCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
