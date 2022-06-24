// <copyright file="LoginCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.AccountValidator
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public LoginCommandValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Email maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(IsValidEmailAddress).WithMessage("The value is not a valid email address");

            RuleFor(v => v.Password)
                .MaximumLength(100).WithMessage("Password maximum length exceeded")
                .NotEmpty().WithMessage("Password must not be empty")
                .NotNull().WithMessage("Password must not be null");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        public bool IsValidEmailAddress(string emailAddress)
        {
            try
            {
                _ = new MailAddress(emailAddress);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
