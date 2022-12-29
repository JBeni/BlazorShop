// <copyright file="GetTodoItemByIdQueryValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoItemValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetTodoItemByIdQuery}"/>.
    /// </summary>
    public class GetTodoItemByIdQueryValidator : AbstractValidator<GetTodoItemByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoItemByIdQueryValidator"/> class.
        /// </summary>
        public GetTodoItemByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
