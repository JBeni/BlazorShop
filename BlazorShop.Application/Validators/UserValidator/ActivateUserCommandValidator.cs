// <copyright file="ActivateUserCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{ActivateUserCommand}"/>.
    /// </summary>
    public class ActivateUserCommandValidator : AbstractValidator<ActivateUserCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivateUserCommandValidator"/> class.
        /// </summary>
        public ActivateUserCommandValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
