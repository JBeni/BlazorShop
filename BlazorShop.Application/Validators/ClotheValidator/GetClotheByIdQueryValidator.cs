// <copyright file="GetClotheByIdQueryValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClotheValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetClotheByIdQuery}"/>.
    /// </summary>
    public class GetClotheByIdQueryValidator : AbstractValidator<GetClotheByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetClotheByIdQueryValidator"/> class.
        /// </summary>
        public GetClotheByIdQueryValidator()
        {
            _ = RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
