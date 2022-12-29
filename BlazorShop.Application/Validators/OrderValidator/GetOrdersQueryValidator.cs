// <copyright file="GetOrdersQueryValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.OrderValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetOrdersQuery}"/>.
    /// </summary>
    public class GetOrdersQueryValidator : AbstractValidator<GetOrdersQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrdersQueryValidator"/> class.
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
