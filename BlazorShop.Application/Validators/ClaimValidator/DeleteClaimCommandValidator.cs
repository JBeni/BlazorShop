// <copyright file="DeleteClaimCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClaimValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteClaimCommand}"/>.
    /// </summary>
    public class DeleteClaimCommandValidator : AbstractValidator<DeleteClaimCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteClaimCommandValidator"/> class.
        /// </summary>
        public DeleteClaimCommandValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
