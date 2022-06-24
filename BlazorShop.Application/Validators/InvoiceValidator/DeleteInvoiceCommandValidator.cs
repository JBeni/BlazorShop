// <copyright file="DeleteInvoiceCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.InvoiceValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteInvoiceCommandValidator : AbstractValidator<DeleteInvoiceCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteInvoiceCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
