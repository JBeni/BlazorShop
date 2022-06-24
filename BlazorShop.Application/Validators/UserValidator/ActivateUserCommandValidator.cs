// <copyright file="ActivateUserCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    public class ActivateUserCommandValidator : AbstractValidator<ActivateUserCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public ActivateUserCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
