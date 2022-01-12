﻿namespace BlazorShop.Application.Validators.CartValidator
{
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        public CreateCartCommandValidator()
        {
            RuleFor(v => v.UserId).GreaterThan(0);
            RuleFor(v => v.ClotheId).GreaterThan(0);
            RuleFor(v => v.Name).NotEmpty().NotNull();
            RuleFor(v => v.Price).GreaterThan(0);
            RuleFor(v => v.Amount).GreaterThan(0);
        }
    }
}
