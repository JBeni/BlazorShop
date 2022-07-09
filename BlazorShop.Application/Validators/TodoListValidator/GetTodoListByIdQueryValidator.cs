// <copyright file="GetTodoListByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoListValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetTodoListByIdQueryValidator : AbstractValidator<GetTodoListByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetTodoListByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
