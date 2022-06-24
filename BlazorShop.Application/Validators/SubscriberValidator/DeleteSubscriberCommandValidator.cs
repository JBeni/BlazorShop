// <copyright file="DeleteSubscriberCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    public class DeleteSubscriberCommandValidator : AbstractValidator<DeleteSubscriberCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteSubscriberCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
