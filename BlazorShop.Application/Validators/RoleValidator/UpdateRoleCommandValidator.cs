// <copyright file="UpdateRoleCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.RoleValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateRoleCommand}"/>.
    /// </summary>
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateRoleCommandValidator"/> class.
        /// </summary>
        public UpdateRoleCommandValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            this.RuleFor(v => v.Name)
                .MaximumLength(100).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null");
        }
    }
}
