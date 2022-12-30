// <copyright file="GetUserByIdQueryValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.UserValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetUserByIdQuery}"/>.
    /// </summary>
    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetUserByIdQueryValidator"/> class.
        /// </summary>
        public GetUserByIdQueryValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
