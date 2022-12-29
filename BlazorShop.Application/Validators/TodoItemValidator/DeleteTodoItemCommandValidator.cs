// <copyright file="DeleteTodoItemCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoItemValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteTodoItemCommand}"/>.
    /// </summary>
    public class DeleteTodoItemCommandValidator : AbstractValidator<DeleteTodoItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTodoItemCommandValidator"/> class.
        /// </summary>
        public DeleteTodoItemCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
