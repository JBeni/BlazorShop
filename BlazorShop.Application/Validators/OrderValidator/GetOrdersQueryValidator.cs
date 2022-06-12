﻿namespace BlazorShop.Application.Validators.OrderValidator
{
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
