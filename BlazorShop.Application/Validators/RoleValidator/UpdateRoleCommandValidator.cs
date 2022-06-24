// <copyright file="UpdateRoleCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.RoleValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public UpdateRoleCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(v => v.Name)
                .MaximumLength(100).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null");
        }
    }
}
