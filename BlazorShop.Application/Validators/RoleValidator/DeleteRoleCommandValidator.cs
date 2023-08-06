// <copyright file="DeleteRoleCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.RoleValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteRoleCommand}"/>.
    /// </summary>
    public class DeleteRoleCommandValidator : AbstractValidator<DeleteRoleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteRoleCommandValidator"/> class.
        /// </summary>
        public DeleteRoleCommandValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
