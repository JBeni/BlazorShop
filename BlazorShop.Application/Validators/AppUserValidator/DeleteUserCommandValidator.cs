﻿namespace BlazorShop.Application.Validators.AppUserValidator
{
    public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidator()
        {
            RuleFor(v => v.Id).GreaterThan(0);
        }
    }
}