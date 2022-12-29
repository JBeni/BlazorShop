// <copyright file="UpdateTodoListCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoListValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateTodoListCommand}"/>.
    /// </summary>
    public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
    {
        /// <summary>
        /// An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateTodoListCommandValidator"/> class.
        /// </summary>
        /// <param name="context">An instance of <see cref="IApplicationDbContext"/>.</param>
        public UpdateTodoListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            RuleFor(x => x.Title)
                .MaximumLength(200).WithMessage("Title maximum length exceeded")
                .NotEmpty().WithMessage("Title must not be empty")
                .NotNull().WithMessage("Title must not be null")
                .MustAsync(HaveUniqueTitle).WithMessage("The specified title already exists.");
        }

        /// <summary>
        /// Gets a value indicating whether the list has an unique title or not.
        /// </summary>
        /// <param name="name">The name of the list.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A boolean value.</returns>
        public async Task<bool> HaveUniqueTitle(string name, CancellationToken cancellationToken)
        {
            return await _context.Carts
                .TagWith(nameof(HaveUniqueTitle))
                .AllAsync(l => l.Name != name, cancellationToken);
        }
    }
}
