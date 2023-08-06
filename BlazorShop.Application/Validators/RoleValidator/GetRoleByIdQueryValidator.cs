// <copyright file="GetRoleByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.RoleValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetRoleByIdQuery}"/>.
    /// </summary>
    public class GetRoleByIdQueryValidator : AbstractValidator<GetRoleByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetRoleByIdQueryValidator"/> class.
        /// </summary>
        public GetRoleByIdQueryValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
