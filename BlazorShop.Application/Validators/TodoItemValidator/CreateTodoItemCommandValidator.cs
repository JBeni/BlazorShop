// <copyright file="CreateTodoItemCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoItemValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// .
        /// </summary>
        public CreateTodoItemCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Equal(0).WithMessage("Id must be equal with 0");

            RuleFor(x => x.ListId)
                .GreaterThan(0).WithMessage("ListId must be greater than 0");

            RuleFor(x => x.Title)
                .MaximumLength(200).WithMessage("Title maximum length exceeded")
                .NotEmpty().WithMessage("Title must not be empty")
                .NotNull().WithMessage("Title must not be null")
                .MustAsync(HaveUniqueTitle).WithMessage("The specified title already exists.");

            RuleFor(x => x.Note)
                .MaximumLength(1000).WithMessage("Note maximum length exceeded")
                .NotEmpty().WithMessage("Note must not be empty")
                .NotNull().WithMessage("Note must not be null");

            RuleFor(x => x.Priority)
                .NotEmpty().WithMessage("Priority must not be empty")
                .NotNull().WithMessage("Priority must not be null");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State must not be empty")
                .NotNull().WithMessage("State must not be null");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> HaveUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}
