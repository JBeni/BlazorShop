// <copyright file="ResetPasswordCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.AccountValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{ResetPasswordCommand}"/>.
    /// </summary>
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPasswordCommandValidator"/> class.
        /// </summary>
        public ResetPasswordCommandValidator()
        {
            this.RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(this.IsValidEmailAddress).WithMessage("The value is not a valid email address");

            this.RuleFor(v => v.NewPassword)
                .MaximumLength(100).WithMessage("NewPassword maximum length exceeded")
                .NotEmpty().WithMessage("NewPassword must not be empty")
                .NotNull().WithMessage("NewPassword must not be null");

            this.RuleFor(v => v.NewConfirmPassword)
                .MaximumLength(100).WithMessage("NewConfirmPassword maximum length exceeded")
                .NotEmpty().WithMessage("NewConfirmPassword must not be empty")
                .NotNull().WithMessage("NewConfirmPassword must not be null")
                .Equal(v => v.NewConfirmPassword).WithMessage("NewPassword must be equal with NewConfirmPassword");
        }

        /// <summary>
        /// A value indicating whether the email address is valid or not.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <returns>A boolean value.</returns>
        public bool IsValidEmailAddress(string emailAddress)
        {
            var isEmailValid = false;
            try
            {
                _ = new MailAddress(emailAddress);
                isEmailValid = true;
            }
            catch (Exception)
            {
            }

            return isEmailValid;
        }
    }
}
