// <copyright file="GetInvoiceByIdQueryValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.InvoiceValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetInvoiceByIdQuery}"/>.
    /// </summary>
    public class GetInvoiceByIdQueryValidator : AbstractValidator<GetInvoiceByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetInvoiceByIdQueryValidator"/> class.
        /// </summary>
        public GetInvoiceByIdQueryValidator()
        {
            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
