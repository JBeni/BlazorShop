// <copyright file="DeleteInvoiceCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.InvoiceValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteInvoiceCommand}"/>.
    /// </summary>
    public class DeleteInvoiceCommandValidator : AbstractValidator<DeleteInvoiceCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteInvoiceCommandValidator"/> class.
        /// </summary>
        public DeleteInvoiceCommandValidator()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
