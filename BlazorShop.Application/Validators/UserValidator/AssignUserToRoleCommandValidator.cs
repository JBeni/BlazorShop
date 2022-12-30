// <copyright file="AssignUserToRoleCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{AssignUserToRoleCommand}"/>.
    /// </summary>
    public class AssignUserToRoleCommandValidator : AbstractValidator<AssignUserToRoleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignUserToRoleCommandValidator"/> class.
        /// </summary>
        public AssignUserToRoleCommandValidator()
        {
            this.RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            this.RuleFor(v => v.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0");
        }
    }
}
