// <copyright file="DeleteTodoItemCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoItemValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
    {
        /// <summary>
        /// .
        /// </summary>
        public DeleteTodoItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
