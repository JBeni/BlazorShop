﻿namespace BlazorShop.Application.Validators.OrderValidator
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.Price).GreaterThan(0);
            RuleFor(v => v.ShippingAddress).NotEmpty().NotNull();
            RuleFor(v => v.SupplierName).NotEmpty().NotNull();
            RuleFor(v => v.BuyerName).NotEmpty().NotNull();
            RuleFor(v => v.Quantity).GreaterThan(0);
        }
    }
}