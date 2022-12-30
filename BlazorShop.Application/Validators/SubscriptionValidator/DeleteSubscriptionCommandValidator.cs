// <copyright file="DeleteSubscriptionCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteSubscriptionCommand}"/>.
    /// </summary>
    public class DeleteSubscriptionCommandValidator : AbstractValidator<DeleteSubscriptionCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriptionCommandValidator"/> class.
        /// </summary>
        public DeleteSubscriptionCommandValidator()
        {
            this.RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
