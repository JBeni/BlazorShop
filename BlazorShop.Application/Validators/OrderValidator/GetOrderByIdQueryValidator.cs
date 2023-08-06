// <copyright file="GetOrderByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.OrderValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetOrderByIdQuery}"/>.
    /// </summary>
    public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetOrderByIdQueryValidator"/> class.
        /// </summary>
        public GetOrderByIdQueryValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            this.RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("UserEmail maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");
        }
    }
}
