// <copyright file="UpdateTodoItemCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoItemValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateTodoItemCommand}"/>.
    /// </summary>
    public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTodoItemCommandValidator"/> class.
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
        /// Gets a value indicating whether the item has an unique title or not.
        /// </summary>
        /// <param name="title">The title of the item.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A boolean value.</returns>
        public async Task<bool> HaveUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                .TagWith(nameof(HaveUniqueTitle))
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}
