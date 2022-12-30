// <copyright file="CreateSubscriberCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{CreateSubscriberCommand}"/>.
    /// </summary>
    public class CreateSubscriberCommandValidator : AbstractValidator<CreateSubscriberCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriberCommandValidator"/> class.
        /// </summary>
        public CreateSubscriberCommandValidator()
        {
            this.RuleFor(x => x.Id)
                .Equal(0).WithMessage("Id must be equal with 0");

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
        }
    }
}
