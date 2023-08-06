// <copyright file="CreateTodoListCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoListValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{CreateTodoListCommand}"/>.
    /// </summary>
    public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateTodoListCommandValidator"/> class.
        /// </summary>
        /// <param name="context">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        public CreateTodoListCommandValidator(IApplicationDbContext context)
        {
            this.Context = context;

            this.RuleFor(x => x.Id)
                .Equal(0).WithMessage("Id must be equal with 0");

            this.RuleFor(x => x.Title)
                .MaximumLength(200).WithMessage("Title maximum length exceeded")
                .NotEmpty().WithMessage("Title must not be empty")
                .NotNull().WithMessage("Title must not be null")
                .MustAsync(this.HaveUniqueTitle).WithMessage("The specified title already exists.");
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext Context { get; }

        /// <summary>
        /// Gets a value indicating whether the list has an unique title or not.
        /// </summary>
        /// <param name="name">The name of the list.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A boolean value.</returns>
        public async Task<bool> HaveUniqueTitle(string name, CancellationToken cancellationToken)
        {
            return await this.Context.Carts
                .TagWith(nameof(this.HaveUniqueTitle))
                .AllAsync(l => l.Name != name, cancellationToken);
        }
    }
}
