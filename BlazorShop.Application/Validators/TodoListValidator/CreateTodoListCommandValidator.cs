// <copyright file="CreateTodoListCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.TodoListValidator
{
    public class CreateTodoListCommandValidator : AbstractValidator<CreateTodoListCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// .
        /// </summary>
        public CreateTodoListCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Equal(0).WithMessage("Id must be equal with 0");

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
                .AllAsync(l => l.Name != name, cancellationToken);
        }
    }
}
