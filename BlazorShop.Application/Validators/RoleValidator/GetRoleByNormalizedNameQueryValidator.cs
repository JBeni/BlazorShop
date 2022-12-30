// <copyright file="GetRoleByNormalizedNameQueryValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.RoleValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetRoleByNormalizedNameQuery}"/>.
    /// </summary>
    public class GetRoleByNormalizedNameQueryValidator : AbstractValidator<GetRoleByNormalizedNameQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleByNormalizedNameQueryValidator"/> class.
        /// </summary>
        public GetRoleByNormalizedNameQueryValidator()
        {
            this.RuleFor(v => v.NormalizedName)
                .MaximumLength(100).WithMessage("NormalizedName maximum length exceeded")
                .NotEmpty().WithMessage("NormalizedName must not be empty")
                .NotNull().WithMessage("NormalizedName must not be null");
        }
    }
}
