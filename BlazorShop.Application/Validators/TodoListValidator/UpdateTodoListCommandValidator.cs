// <copyright file="UpdateTodoListCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoListValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class UpdateTodoListCommandValidator : AbstractValidator<UpdateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// .
        /// </summary>
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
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> HaveUniqueTitle(string name, CancellationToken cancellationToken)
        {
            return await _context.Carts
                .TagWith(nameof(HaveUniqueTitle))
                .AllAsync(l => l.Name != name, cancellationToken);
        }
    }
}
