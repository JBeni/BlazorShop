// <copyright file="ChangePasswordCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.AccountValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{ChangePasswordCommand}"/>.
    /// </summary>
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangePasswordCommandValidator"/> class.
        /// </summary>
        public ChangePasswordCommandValidator()
        {
            _ = this.RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            _ = this.RuleFor(v => v.OldPassword)
                .NotEmpty().WithMessage("OldPassword must not be empty")
                .NotNull().WithMessage("OldPassword must not be null")
                .NotEqual(v => v.NewPassword).WithMessage("OldPassword must not be equal with NewPassword");

            _ = this.RuleFor(v => v.NewPassword)
                .NotEmpty().WithMessage("NewPassword must not be empty")
                .NotNull().WithMessage("NewPassword must not be null");

            _ = this.RuleFor(v => v.ConfirmNewPassword)
                .NotEmpty().WithMessage("ConfirmNewPassword must not be empty")
                .NotNull().WithMessage("ConfirmNewPassword must not be null")
                .Equal(v => v.NewPassword).WithMessage("NewPassword must be equal with ConfirmNewPassword");
        }
    }
}
