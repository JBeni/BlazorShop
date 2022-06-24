// <copyright file="GetUserByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetUserByIdQueryValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
