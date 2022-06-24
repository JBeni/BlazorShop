// <copyright file="GetSubscriberByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class GetSubscriberByIdQueryValidator : AbstractValidator<GetSubscriberByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetSubscriberByIdQueryValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
