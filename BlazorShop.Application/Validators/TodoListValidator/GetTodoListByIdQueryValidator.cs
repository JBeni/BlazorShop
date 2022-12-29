// <copyright file="GetTodoListByIdQueryValidator.cs" author="Beniamin Jitca">
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
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
