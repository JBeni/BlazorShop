// <copyright file="GetTodoListByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoListValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{GetTodoListByIdQuery}"/>.
    /// </summary>
    public class GetTodoListByIdQueryValidator : AbstractValidator<GetTodoListByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTodoListByIdQueryValidator"/> class.
        /// </summary>
        public GetTodoListByIdQueryValidator()
        {
            this.RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
