// <copyright file="UpdateUserEmailCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateUserEmailCommand}"/>.
    /// </summary>
    public class UpdateUserEmailCommandValidator : AbstractValidator<UpdateUserEmailCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserEmailCommandValidator"/> class.
        /// </summary>
        public UpdateUserEmailCommandValidator()
        {
            this.RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            this.RuleFor(v => v.Email)
                .MaximumLength(150).WithMessage("Email maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(this.IsValidEmailAddress).WithMessage("The Email address is not valid");

            this.RuleFor(v => v.NewEmail)
                .MaximumLength(150).WithMessage("NewEmail maximum length exceeded")
                .NotEmpty().WithMessage("NewEmail must not be empty")
                .NotNull().WithMessage("NewEmail must not be null")
                .NotEqual(v => v.Email).WithMessage("NewEmail must not be equal with Email")
                .Must(this.IsValidEmailAddress).WithMessage("The NewEmail address is not valid");
        }

        /// <summary>
        /// Gets a value indicating whether the user has a valid email or not.
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
