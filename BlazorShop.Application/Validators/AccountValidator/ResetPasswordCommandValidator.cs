// <copyright file="ResetPasswordCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.AccountValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public ResetPasswordCommandValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(100).WithMessage("Maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(IsValidEmailAddress).WithMessage("The value is not a valid email address");

            RuleFor(v => v.NewPassword)
                .MaximumLength(100).WithMessage("NewPassword maximum length exceeded")
                .NotEmpty().WithMessage("NewPassword must not be empty")
                .NotNull().WithMessage("NewPassword must not be null");

            RuleFor(v => v.NewConfirmPassword)
                .MaximumLength(100).WithMessage("NewConfirmPassword maximum length exceeded")
                .NotEmpty().WithMessage("NewConfirmPassword must not be empty")
                .NotNull().WithMessage("NewConfirmPassword must not be null")
                .Equal(v => v.NewConfirmPassword).WithMessage("NewPassword must be equal with NewConfirmPassword");
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
