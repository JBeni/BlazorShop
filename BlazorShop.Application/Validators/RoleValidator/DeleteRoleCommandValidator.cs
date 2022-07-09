// <copyright file="DeleteRoleCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.RoleValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteRoleCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
