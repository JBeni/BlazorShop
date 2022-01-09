﻿namespace BlazorShop.Application.Validators.OrderValidator
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DeleteOrderCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}