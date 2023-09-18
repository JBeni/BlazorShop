// <copyright file="UpdateClaimCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClaimValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateClaimCommand}"/>.
    /// </summary>
    public class UpdateClaimCommandValidator : AbstractValidator<UpdateClaimCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateClaimCommandValidator"/> class.
        /// </summary>
        public UpdateClaimCommandValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            this.RuleFor(v => v.Value)
                .MaximumLength(50).WithMessage("Value maximum length exceeded")
                .NotEmpty().WithMessage("Value must not be empty")
                .NotNull().WithMessage("Value must not be null");

            this.RuleFor(v => v.Type)
                .MaximumLength(150).WithMessage("Type maximum length exceeded")
                .NotEmpty().WithMessage("Type must not be empty")
                .NotNull().WithMessage("Type must not be null");
        }
    }
}
