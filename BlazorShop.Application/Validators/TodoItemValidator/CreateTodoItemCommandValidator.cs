// <copyright file="CreateTodoItemCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoItemValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{CreateTodoItemCommand}"/>.
    /// </summary>
    public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoItemCommandValidator"/> class.
        /// </summary>
        /// <param name="context">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        public CreateTodoItemCommandValidator(IApplicationDbContext context)
        {
            this.Context = context;

            this.RuleFor(x => x.Id)
                .Equal(0).WithMessage("Id must be equal with 0");

            this.RuleFor(x => x.ListId)
                .GreaterThan(0).WithMessage("ListId must be greater than 0");

            this.RuleFor(x => x.Title)
                .MaximumLength(200).WithMessage("Title maximum length exceeded")
                .NotEmpty().WithMessage("Title must not be empty")
                .NotNull().WithMessage("Title must not be null")
                .MustAsync(this.HaveUniqueTitle).WithMessage("The specified title already exists.");

            this.RuleFor(x => x.Note)
                .MaximumLength(1000).WithMessage("Note maximum length exceeded")
                .NotEmpty().WithMessage("Note must not be empty")
                .NotNull().WithMessage("Note must not be null");

            this.RuleFor(x => x.Priority)
                .NotEmpty().WithMessage("Priority must not be empty")
                .NotNull().WithMessage("Priority must not be null");

            this.RuleFor(x => x.State)
                .NotEmpty().WithMessage("State must not be empty")
                .NotNull().WithMessage("State must not be null");
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext Context { get; }

        /// <summary>
        /// Gets a value indicating whether the item has an unique title or not.
        /// </summary>
        /// <param name="title">The title of the item.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A boolean value.</returns>
        public async Task<bool> HaveUniqueTitle(string title, CancellationToken cancellationToken)
        {
            return await this.Context.TodoItems
                .TagWith(nameof(this.HaveUniqueTitle))
                .AllAsync(l => l.Title != title, cancellationToken);
        }
    }
}
