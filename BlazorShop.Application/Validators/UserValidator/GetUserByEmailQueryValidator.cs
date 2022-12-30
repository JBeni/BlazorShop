// <copyright file="GetUserByEmailQueryValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetUserByEmailQuery}"/>.
    /// </summary>
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByEmailQueryValidator"/> class.
        /// </summary>
        public GetUserByEmailQueryValidator()
        {
            this.RuleFor(v => v.Email)
                .MaximumLength(150).WithMessage("Email maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(this.IsValidEmailAddress).WithMessage("The value is not a valid email address");
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
