// <copyright file="CreateUserCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(150).WithMessage("Email maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(IsValidEmailAddress).WithMessage("The value is not a valid email address");

            RuleFor(v => v.FirstName)
                .MaximumLength(100).WithMessage("FirstName maximum length exceeded")
                .NotEmpty().WithMessage("FirstName must not be empty")
                .NotNull().WithMessage("FirstName must not be null");

            RuleFor(v => v.LastName)
                .MaximumLength(100).WithMessage("LastName maximum length exceeded")
                .NotEmpty().WithMessage("LastName must not be empty")
                .NotNull().WithMessage("LastName must not be null");

            RuleFor(v => v.Role)
                .MaximumLength(25).WithMessage("Role maximum length exceeded")
                .NotEmpty().WithMessage("Role must not be empty")
                .NotNull().WithMessage("Role must not be null");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
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
