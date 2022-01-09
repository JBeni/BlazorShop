﻿namespace BlazorShop.Application.Validators.ClotheValidator
{
    public class DeleteClotheCommandValidator : AbstractValidator<DeleteClotheCommand>
    {
        public DeleteClotheCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}