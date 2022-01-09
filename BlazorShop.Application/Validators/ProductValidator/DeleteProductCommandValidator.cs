﻿namespace BlazorShop.Application.Validators.ProductValidator
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}