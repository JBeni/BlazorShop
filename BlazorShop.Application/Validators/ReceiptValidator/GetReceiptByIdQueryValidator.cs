// <copyright file="GetReceiptByIdQueryValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ReceiptValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetReceiptByIdQuery}"/>.
    /// </summary>
    public class GetReceiptByIdQueryValidator : AbstractValidator<GetReceiptByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetReceiptByIdQueryValidator"/> class.
        /// </summary>
        public GetReceiptByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("UserEmail maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");
        }
    }
}
