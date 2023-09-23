// <copyright file="CreateClaimCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClaimValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{CreateClaimCommand}"/>.
    /// </summary>
    public class CreateClaimCommandValidator : AbstractValidator<CreateClaimCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClaimCommandValidator"/> class.
        /// </summary>
        public CreateClaimCommandValidator()
        {
            this.RuleFor(v => v.Value)
                .MaximumLength(50).WithMessage("Value maximum length exceeded")
                .NotEmpty().WithMessage("Value must not be empty")
                .NotNull().WithMessage("Value must not be null");

            this.RuleFor(v => v.Type)
                .MaximumLength(250).WithMessage("Type maximum length exceeded")
                .NotEmpty().WithMessage("Type must not be empty")
                .NotNull().WithMessage("Type must not be null");
        }
    }
}
