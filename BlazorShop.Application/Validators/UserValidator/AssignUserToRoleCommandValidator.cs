// <copyright file="AssignUserToRoleCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    public class AssignUserToRoleCommandValidator : AbstractValidator<AssignUserToRoleCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public AssignUserToRoleCommandValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(v => v.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0");
        }
    }
}
