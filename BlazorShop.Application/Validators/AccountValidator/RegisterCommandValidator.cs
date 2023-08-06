// <copyright file="RegisterCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.AccountValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{RegisterCommand}"/>.
    /// </summary>
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCommandValidator"/> class.
        /// </summary>
        public RegisterCommandValidator()
        {
            this.RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Email maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(this.IsValidEmailAddress).WithMessage("The value is not a valid email address");

            this.RuleFor(v => v.FirstName)
                .MaximumLength(100).WithMessage("FirstName maximum length exceeded")
                .NotEmpty().WithMessage("FirstName must not be empty")
                .NotNull().WithMessage("FirstName must not be null");

            this.RuleFor(v => v.LastName)
                .MaximumLength(100).WithMessage("LastName maximum length exceeded")
                .NotEmpty().WithMessage("LastName must not be empty")
                .NotNull().WithMessage("LastName must not be null");

            this.RuleFor(v => v.Password)
                .MaximumLength(100).WithMessage("Password maximum length exceeded")
                .NotEmpty().WithMessage("Password must not be empty")
                .NotNull().WithMessage("Password must not be null");

            this.RuleFor(v => v.ConfirmPassword)
                .MaximumLength(100).WithMessage("ConfirmPassword maximum length exceeded")
                .NotEmpty().WithMessage("ConfirmPassword must not be empty")
                .NotNull().WithMessage("ConfirmPassword must not be null")
                .Equal(v => v.Password).WithMessage("ConfirmPassword must be equal with Password");
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
