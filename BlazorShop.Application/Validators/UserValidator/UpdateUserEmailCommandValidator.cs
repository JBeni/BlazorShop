// <copyright file="UpdateUserEmailCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateUserEmailCommandValidator : AbstractValidator<UpdateUserEmailCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public UpdateUserEmailCommandValidator()
        {
            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(v => v.Email)
                .MaximumLength(150).WithMessage("Email maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(IsValidEmailAddress).WithMessage("The Email address is not valid");

            RuleFor(v => v.NewEmail)
                .MaximumLength(150).WithMessage("NewEmail maximum length exceeded")
                .NotEmpty().WithMessage("NewEmail must not be empty")
                .NotNull().WithMessage("NewEmail must not be null")
                .NotEqual(v => v.Email).WithMessage("NewEmail must not be equal with Email")
                .Must(IsValidEmailAddress).WithMessage("The NewEmail address is not valid");
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
