// <copyright file="UpdateCartCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.CartValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateCartCommand}"/>.
    /// </summary>
    public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateCartCommandValidator"/> class.
        /// </summary>
        /// <param name="context">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        public UpdateCartCommandValidator(IApplicationDbContext context)
        {
            this.Context = context;

            this.RuleFor(v => v.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0");

            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            this.RuleFor(v => v.ClotheId)
                .GreaterThan(0).WithMessage("ClotheId must be greater than 0");

            this.RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MustAsync(this.HaveUniqueName).WithMessage("The specified name already exists.");

            this.RuleFor(v => v.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            this.RuleFor(v => v.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext Context { get; }

        /// <summary>
        /// Gets a value indicating whether the cart has an unique name or not.
        /// </summary>
        /// <param name="name">The name of the cart.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A boolean value.</returns>
        public async Task<bool> HaveUniqueName(string name, CancellationToken cancellationToken)
        {
            return await this.Context.Carts
                .TagWith(nameof(this.HaveUniqueName))
                .AllAsync(l => l.Name != name, cancellationToken);
        }
    }
}
