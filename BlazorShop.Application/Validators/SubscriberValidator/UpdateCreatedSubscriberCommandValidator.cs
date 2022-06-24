// <copyright file="UpdateCreatedSubscriberCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateCreatedSubscriberCommandValidator : AbstractValidator<UpdateCreatedSubscriberCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public UpdateCreatedSubscriberCommandValidator()
        {
            RuleFor(x => x.CurrentPeriodStart)
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-1)).WithMessage("CurrentPeriodStart must be greater or equal than Current Date")
                .NotEmpty().WithMessage("CurrentPeriodStart must not be empty")
                .NotNull().WithMessage("CurrentPeriodStart must not be null");

            RuleFor(x => x.CurrentPeriodEnd)
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-1)).WithMessage("CurrentPeriodEnd must be greater or equal than Current Date")
                .NotEmpty().WithMessage("CurrentPeriodEnd must not be empty")
                .NotNull().WithMessage("CurrentPeriodEnd must not be null");

            RuleFor(x => x.CustomerEmail)
                .NotEmpty().WithMessage("CustomerEmail must not be empty")
                .NotNull().WithMessage("CustomerEmail must not be null");

            RuleFor(x => x.StripeSubscriberSubscriptionId)
                .MaximumLength(500).WithMessage("StripeSubscriberSubscriptionId maximum length exceeded")
                .NotEmpty().WithMessage("StripeSubscriberSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriberSubscriptionId must not be null");

            RuleFor(x => x.HostedInvoiceUrl)
                .MaximumLength(700).WithMessage("HostedInvoiceUrl maximum length exceeded")
                .NotEmpty().WithMessage("HostedInvoiceUrl must not be empty")
                .NotNull().WithMessage("HostedInvoiceUrl must not be null");
        }
    }
}
