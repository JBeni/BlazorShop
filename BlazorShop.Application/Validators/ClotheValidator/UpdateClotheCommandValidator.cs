// <copyright file="UpdateClotheCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClotheValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{UpdateClotheCommand}"/>.
    /// </summary>
    public class UpdateClotheCommandValidator : AbstractValidator<UpdateClotheCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateClotheCommandValidator"/> class.
        /// </summary>
        /// <param name="context">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        public UpdateClotheCommandValidator(IApplicationDbContext context)
        {
            this.Context = context;

            this.RuleFor(v => v.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0");

            this.RuleFor(v => v.Name)
                .MaximumLength(200).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MustAsync(this.HaveUniqueName).WithMessage("The specified name already exists.");

            this.RuleFor(v => v.Description)
                .MaximumLength(1000).WithMessage("Description maximum length exceeded")
                .NotEmpty().WithMessage("Description must not be empty")
                .NotNull().WithMessage("Description must not be null");

            this.RuleFor(v => v.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            this.RuleFor(v => v.Amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");

            this.RuleFor(v => v.ImageName)
                .MaximumLength(200).WithMessage("ImageName maximum length exceeded")
                .NotEmpty().WithMessage("ImageName must not be empty")
                .NotNull().WithMessage("ImageName must not be null");

            this.RuleFor(v => v.ImagePath)
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
