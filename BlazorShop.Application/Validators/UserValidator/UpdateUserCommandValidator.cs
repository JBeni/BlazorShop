// <copyright file="UpdateUserCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateUserCommand}"/>.
    /// </summary>
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserCommandValidator"/> class.
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
