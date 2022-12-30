// <copyright file="GetUserSubscribersQueryValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetUserSubscribersQuery}"/>.
    /// </summary>
    public class GetUserSubscribersQueryValidator : AbstractValidator<GetUserSubscribersQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserSubscribersQueryValidator"/> class.
        /// </summary>
        public GetUserSubscribersQueryValidator()
        {
            this.RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
