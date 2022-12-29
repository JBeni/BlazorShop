// <copyright file="GetReceiptsQueryValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ReceiptValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetReceiptsQuery}"/>.
    /// </summary>
    public class GetReceiptsQueryValidator : AbstractValidator<GetReceiptsQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetReceiptsQueryValidator"/> class.
        /// </summary>
        public GetReceiptsQueryValidator()
        {
            RuleFor(v => v.UserEmail)
                .MaximumLength(100).WithMessage("UserEmail maximum length exceeded")
                .NotEmpty().WithMessage("UserEmail must not be empty")
                .NotNull().WithMessage("UserEmail must not be null");
        }
    }
}
