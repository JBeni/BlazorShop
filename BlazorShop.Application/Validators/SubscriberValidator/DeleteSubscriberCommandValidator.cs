// <copyright file="DeleteSubscriberCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriberValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteSubscriberCommand}"/>.
    /// </summary>
    public class DeleteSubscriberCommandValidator : AbstractValidator<DeleteSubscriberCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteSubscriberCommandValidator"/> class.
        /// </summary>
        public DeleteSubscriberCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
