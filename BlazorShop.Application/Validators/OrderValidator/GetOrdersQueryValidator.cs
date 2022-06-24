// <copyright file="GetOrdersQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.OrderValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetOrdersQueryValidator()
        {
            RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("UserEmail maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");
        }
    }
}
