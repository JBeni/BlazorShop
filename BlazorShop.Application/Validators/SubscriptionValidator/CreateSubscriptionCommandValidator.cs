// <copyright file="CreateSubscriptionCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{CreateSubscriptionCommand}"/>.
    /// </summary>
    public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateSubscriptionCommandValidator"/> class.
        /// </summary>
        /// <param name="context">Gets An instance of <see cref="IApplicationDbContext"/>.</param>
        public CreateSubscriptionCommandValidator(IApplicationDbContext context)
        {
            this.Context = context;

            this.RuleFor(x => x.Id)
                .Equal(0).WithMessage("Id must be equal with 0");

            this.RuleFor(x => x.StripeSubscriptionId)
                .NotEmpty().WithMessage("StripeSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriptionId must not be null");

            this.RuleFor(x => x.Name)
                .MaximumLength(200).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MustAsync(this.HaveUniqueName).WithMessage("The specified name already exists.");

            this.RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            this.RuleFor(x => x.Options)
                .MaximumLength(1000).WithMessage("Options maximum length exceeded")
                .NotEmpty().WithMessage("Options must not be empty")
                .NotNull().WithMessage("Options must not be null");

            this.RuleFor(x => x.ImageName)
                .MaximumLength(200).WithMessage("ImageName maximum length exceeded")
                .NotEmpty().WithMessage("ImageName must not be empty")
                .NotNull().WithMessage("ImageName must not be null");

            this.RuleFor(x => x.ImagePath)
                .MaximumLength(200).WithMessage("ImagePath maximum length exceeded")
                .NotEmpty().WithMessage("ImagePath must not be empty")
                .NotNull().WithMessage("ImagePath must not be null");
        }

        /// <summary>
        /// Gets An instance of <see cref="IApplicationDbContext"/>.
        /// </summary>
        private IApplicationDbContext Context { get; }

        /// <summary>
        /// Gets a value indicating whether the subscription has an unique name or not.
        /// </summary>
        /// <param name="name">The name of the subscription.</param>
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
