// <copyright file="GetUserByEmailQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    public class GetUserByEmailQueryValidator : AbstractValidator<GetUserByEmailQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetUserByEmailQueryValidator()
        {
            RuleFor(v => v.Email)
                .MaximumLength(150).WithMessage("Email maximum length exceeded")
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .Must(IsValidEmailAddress).WithMessage("The value is not a valid email address");
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
