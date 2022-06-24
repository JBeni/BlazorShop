// <copyright file="CreateRoleCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.RoleValidator
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public CreateRoleCommandValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(100).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null");
        }
    }
}
