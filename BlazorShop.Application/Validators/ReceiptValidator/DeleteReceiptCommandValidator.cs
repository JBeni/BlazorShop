// <copyright file="DeleteReceiptCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ReceiptValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteReceiptCommand}"/>.
    /// </summary>
    public class DeleteReceiptCommandValidator : AbstractValidator<DeleteReceiptCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteReceiptCommandValidator"/> class.
        /// </summary>
        public DeleteReceiptCommandValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
