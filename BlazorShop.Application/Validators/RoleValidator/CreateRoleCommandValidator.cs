// <copyright file="CreateRoleCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.RoleValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{CreateRoleCommand}"/>.
    /// </summary>
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRoleCommandValidator"/> class.
        /// </summary>
        public CreateRoleCommandValidator()
        {
            this.RuleFor(v => v.Name)
                .MaximumLength(100).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null");
        }
    }
}
