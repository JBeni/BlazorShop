// <copyright file="GetRoleByNormalizedNameQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.RoleValidator
{
    public class GetRoleByNormalizedNameQueryValidator : AbstractValidator<GetRoleByNormalizedNameQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetRoleByNormalizedNameQueryValidator()
        {
            RuleFor(v => v.NormalizedName)
                .MaximumLength(100).WithMessage("NormalizedName maximum length exceeded")
                .NotEmpty().WithMessage("NormalizedName must not be empty")
                .NotNull().WithMessage("NormalizedName must not be null");
        }
    }
}
