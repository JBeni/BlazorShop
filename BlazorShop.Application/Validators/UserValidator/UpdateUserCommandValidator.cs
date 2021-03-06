// <copyright file="UpdateUserCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(v => v.FirstName)
                .MaximumLength(100).WithMessage("FirstName maximum length exceeded")
                .NotEmpty().WithMessage("FirstName must not be empty")
                .NotNull().WithMessage("FirstName must not be null");

            RuleFor(v => v.LastName)
                .MaximumLength(100).WithMessage("LastName maximum length exceeded")
                .NotEmpty().WithMessage("LastName must not be empty")
                .NotNull().WithMessage("LastName must not be null");

            RuleFor(v => v.Role)
                .MaximumLength(25).WithMessage("Role maximum length exceeded")
                .NotEmpty().WithMessage("Role must not be empty")
                .NotNull().WithMessage("Role must not be null");
        }
    }
}
