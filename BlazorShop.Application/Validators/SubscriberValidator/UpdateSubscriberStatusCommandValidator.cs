// <copyright file="UpdateSubscriberStatusCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateSubscriberStatusCommandValidator : AbstractValidator<UpdateSubscriberStatusCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public UpdateSubscriberStatusCommandValidator()
        {
            RuleFor(x => x.StripeSubscriberSubscriptionId)
                .MaximumLength(500).WithMessage("StripeSubscriberSubscriptionId maximum length exceeded")
                .NotEmpty().WithMessage("StripeSubscriberSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriberSubscriptionId must not be null");
        }
    }
}
