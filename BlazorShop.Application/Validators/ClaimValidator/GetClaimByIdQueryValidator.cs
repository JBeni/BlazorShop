// <copyright file="GetClaimByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClaimValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetClaimByIdQuery}"/>.
    /// </summary>
    public class GetClaimByIdQueryValidator : AbstractValidator<GetClaimByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClaimByIdQueryValidator"/> class.
        /// </summary>
        public GetClaimByIdQueryValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
