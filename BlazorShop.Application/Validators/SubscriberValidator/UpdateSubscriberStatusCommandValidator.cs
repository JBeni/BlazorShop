// <copyright file="UpdateSubscriberStatusCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateSubscriberStatusCommand}"/>.
    /// </summary>
    public class UpdateSubscriberStatusCommandValidator : AbstractValidator<UpdateSubscriberStatusCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriberStatusCommandValidator"/> class.
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
