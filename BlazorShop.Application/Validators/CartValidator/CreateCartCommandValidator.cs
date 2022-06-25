// <copyright file="CreateCartCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// .
        /// </summary>
        public CreateCartCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            RuleFor(v => v.ClotheId)
                .GreaterThan(0).WithMessage("ClotheId must be greater than 0");

            RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MustAsync(HaveUniqueName).WithMessage("The specified name already exists.");

            RuleFor(v => v.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(v => v.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> HaveUniqueName(string name, CancellationToken cancellationToken)
        {
            return await _context.Carts
                .TagWith(nameof(HaveUniqueName))
                .AllAsync(l => l.Name != name, cancellationToken);
        }
    }
}
