// <copyright file="CreateClotheCommandValidator.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClotheValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{CreateClotheCommand}"/>.
    /// </summary>
    public class CreateClotheCommandValidator : AbstractValidator<CreateClotheCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClotheCommandValidator"/> class.
        /// </summary>
        /// <param name="context">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        public CreateClotheCommandValidator(IApplicationDbContext context)
        {
            this.Context = context;

            _ = this.RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .MustAsync(this.HaveUniqueName).WithMessage("The name already exists.");

            _ = this.RuleFor(v => v.Description)
                .MaximumLength(1000).WithMessage("Description maximum length exceeded")
                .NotEmpty().WithMessage("Description must not be empty")
                .NotNull().WithMessage("Description must not be null");

            _ = this.RuleFor(v => v.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            _ = this.RuleFor(v => v.Amount)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            _ = this.RuleFor(v => v.ImageName)
                .MaximumLength(200).WithMessage("ImageName maximum length exceeded")
                .NotEmpty().WithMessage("ImageName must not be empty")
                .NotNull().WithMessage("ImageName must not be null");

            _ = this.RuleFor(v => v.ImagePath)
                .MaximumLength(200).WithMessage("ImagePath maximum length exceeded")
                .NotEmpty().WithMessage("ImagePath must not be empty")
                .NotNull().WithMessage("ImagePath must not be null");
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext Context { get; }

        /// <summary>
        /// Gets a value indicating whether the clothe has an unique name or not.
        /// </summary>
        /// <param name="name">The name of the clothe.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A boolean value.</returns>
        public async Task<bool> HaveUniqueName(string name, CancellationToken cancellationToken)
        {
            return await this.Context.Clothes
                .TagWith(nameof(this.HaveUniqueName))
                .AllAsync(l => l.Name != name, cancellationToken);
        }
    }
}
