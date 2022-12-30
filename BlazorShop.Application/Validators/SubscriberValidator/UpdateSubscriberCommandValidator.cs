// <copyright file="UpdateSubscriberCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateSubscriberCommand}"/>.
    /// </summary>
    public class UpdateSubscriberCommandValidator : AbstractValidator<UpdateSubscriberCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateSubscriberCommandValidator"/> class.
        /// </summary>
        public UpdateSubscriberCommandValidator()
        {
            this.RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            this.RuleFor(x => x.DateStart)
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-1)).WithMessage("DateStart must be greater or equal than Current Date")
                .NotEmpty().WithMessage("DateStart must not be empty")
                .NotNull().WithMessage("DateStart must not be null");

            this.RuleFor(x => x.CurrentPeriodEnd)
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-1)).WithMessage("CurrentPeriodEnd must be greater or equal than Current Date")
                .NotEmpty().WithMessage("CurrentPeriodEnd must not be empty")
                .NotNull().WithMessage("CurrentPeriodEnd must not be null");

            this.RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("CustomerId must be greater than 0");

            this.RuleFor(x => x.SubscriptionId)
                .GreaterThan(0).WithMessage("SubscriptionId must be greater than 0");

            this.RuleFor(x => x.StripeSubscriptionId)
                .NotEmpty().WithMessage("StripeSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriptionId must not be null");

            this.RuleFor(x => x.StripeSubscriberSubscriptionId)
                .MaximumLength(500).WithMessage("StripeSubscriberSubscriptionId maximum length exceeded")
                .NotEmpty().WithMessage("StripeSubscriberSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriberSubscriptionId must not be null");
        }
    }
}
