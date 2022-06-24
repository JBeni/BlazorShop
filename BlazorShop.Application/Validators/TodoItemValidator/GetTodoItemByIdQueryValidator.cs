// <copyright file="GetTodoItemByIdQueryValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoItemValidator
{
    public  class GetTodoItemByIdQueryValidator : AbstractValidator<GetTodoItemByIdQuery>
    {
        /// <summary>
        /// .
        /// </summary>
        public GetTodoItemByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");
        }
    }
}
