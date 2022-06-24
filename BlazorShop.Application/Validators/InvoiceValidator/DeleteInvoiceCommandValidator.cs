// <copyright file="DeleteInvoiceCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.InvoiceValidator
{
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
