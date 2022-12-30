// <copyright file="GetSubscriberByIdQueryValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetSubscriberByIdQuery}"/>.
    /// </summary>
    public class GetSubscriberByIdQueryValidator : AbstractValidator<GetSubscriberByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetSubscriberByIdQueryValidator"/> class.
        /// </summary>
        public GetSubscriberByIdQueryValidator()
        {
            this.RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
