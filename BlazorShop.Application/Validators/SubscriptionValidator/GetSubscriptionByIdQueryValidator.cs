// <copyright file="GetSubscriptionByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetSubscriptionByIdQuery}"/>.
    /// </summary>
    public class GetSubscriptionByIdQueryValidator : AbstractValidator<GetSubscriptionByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriptionByIdQueryValidator"/> class.
        /// </summary>
        public GetSubscriptionByIdQueryValidator()
        {
            this.RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
