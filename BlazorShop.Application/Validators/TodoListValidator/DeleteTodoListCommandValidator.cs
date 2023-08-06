// <copyright file="DeleteTodoListCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoListValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{DeleteTodoListCommand}"/>.
    /// </summary>
    public class DeleteTodoListCommandValidator : AbstractValidator<DeleteTodoListCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteTodoListCommandValidator"/> class.
        /// </summary>
        public DeleteTodoListCommandValidator()
        {
            this.RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
