// <copyright file="UpdateTodoItemCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoItemValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// .
        /// </summary>
        public UpdateTodoItemCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

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

            RuleFor(x => x.Done)
                .NotEmpty().WithMessage("Done must not be empty")
                .NotNull().WithMessage("Done must not be null");
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
                .TagWith(nameof(HaveUniqueTitle))
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}
