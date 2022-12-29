// <copyright file="DeleteClotheCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClotheValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteClotheCommand}"/>.
    /// </summary>
    public class DeleteClotheCommandValidator : AbstractValidator<DeleteClotheCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteClotheCommandValidator"/> class.
        /// </summary>
        public DeleteClotheCommandValidator()
        {
            _ = RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
