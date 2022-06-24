// <copyright file="DeleteSubscriptionCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    public class DeleteSubscriptionCommandValidator : AbstractValidator<DeleteSubscriptionCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteSubscriptionCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
