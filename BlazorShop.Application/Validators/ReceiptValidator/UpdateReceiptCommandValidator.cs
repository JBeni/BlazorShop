// <copyright file="UpdateReceiptCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ReceiptValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateReceiptCommandValidator : AbstractValidator<UpdateReceiptCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public UpdateReceiptCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("UserEmail maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");

            RuleFor(v => v.ReceiptDate)
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(-1)).WithMessage("ReceiptDate must be greater or equal than Current Date")
                .NotEmpty().WithMessage("ReceiptDate must not be empty")
                .NotNull().WithMessage("ReceiptDate must not be null");

            RuleFor(v => v.ReceiptName)
                .MaximumLength(200).WithMessage("ReceiptName maximum length exceeded")
                .NotEmpty().WithMessage("ReceiptName must not be empty")
                .NotNull().WithMessage("ReceiptName must not be null");

            RuleFor(v => v.ReceiptUrl)
                .MaximumLength(500).WithMessage("ReceiptUrl maximum length exceeded")
                .NotEmpty().WithMessage("ReceiptUrl must not be empty")
                .NotNull().WithMessage("ReceiptUrl must not be null");
        }
    }
}
