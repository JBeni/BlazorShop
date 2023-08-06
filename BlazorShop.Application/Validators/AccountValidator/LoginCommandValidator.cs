// <copyright file="LoginCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.AccountValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{LoginCommand}"/>.
    /// </summary>
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginCommandValidator"/> class.
        /// </summary>
        public LoginCommandValidator()
        {
            this.RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Email maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(this.IsValidEmailAddress).WithMessage("The value is not a valid email address");

            this.RuleFor(v => v.Password)
                .MaximumLength(100).WithMessage("Password maximum length exceeded")
                .NotEmpty().WithMessage("Password must not be empty")
                .NotNull().WithMessage("Password must not be null");
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
