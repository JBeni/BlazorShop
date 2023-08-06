// <copyright file="UpdateOrderCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.OrderValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateOrderCommand}"/>.
    /// </summary>
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateOrderCommandValidator"/> class.
        /// </summary>
        public UpdateOrderCommandValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            this.RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("UserEmail maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");

            this.RuleFor(v => v.OrderDate)
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-1)).WithMessage("OrderDate must be greater or equal with Current Date")
                .NotEmpty().WithMessage("OrderDate must not be empty")
                .NotNull().WithMessage("OrderDate must not be null");

            this.RuleFor(v => v.LineItems)
                .MaximumLength(10000).WithMessage("LineItems maximum length exceeded")
                .NotEmpty().WithMessage("LineItems must not be empty")
                .NotNull().WithMessage("LineItems must not be null");

            this.RuleFor(v => v.AmountTotal)
                .GreaterThan(0).WithMessage("AmountTotal must be greater than 0");
        }
    }
}
