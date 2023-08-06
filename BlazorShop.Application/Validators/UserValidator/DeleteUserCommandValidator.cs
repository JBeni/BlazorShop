// <copyright file="DeleteUserCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteUserCommand}"/>.
    /// </summary>
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteUserCommandValidator"/> class.
        /// </summary>
        public DeleteUserCommandValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
