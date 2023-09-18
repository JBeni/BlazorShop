// <copyright file="GetClaimByValueQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClaimValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetClaimByValueQuery}"/>.
    /// </summary>
    public class GetClaimByValueQueryValidator : AbstractValidator<GetClaimByValueQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClaimByValueQueryValidator"/> class.
        /// </summary>
        public GetClaimByValueQueryValidator()
        {
            this.RuleFor(v => v.Value)
                .MaximumLength(50).WithMessage("Value maximum length exceeded")
                .NotEmpty().WithMessage("Value must not be empty")
                .NotNull().WithMessage("Value must not be null");
        }
    }
}
