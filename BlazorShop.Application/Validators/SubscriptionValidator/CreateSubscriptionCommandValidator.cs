// <copyright file="CreateSubscriptionCommandValidator.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.SubscriptionValidator
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class CreateSubscriptionCommandValidator : AbstractValidator<CreateSubscriptionCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// .
        /// </summary>
        public CreateSubscriptionCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(x => x.Id)
                .Equal(0).WithMessage("Id must be equal with 0");

            RuleFor(x => x.StripeSubscriptionId)
                .NotEmpty().WithMessage("StripeSubscriptionId must not be empty")
                .NotNull().WithMessage("StripeSubscriptionId must not be null");

            RuleFor(x => x.Name)
                .MaximumLength(200).WithMessage("Name maximum length exceeded")
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MustAsync(HaveUniqueName).WithMessage("The specified name already exists.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(x => x.Options)
                .MaximumLength(1000).WithMessage("Options maximum length exceeded")
                .NotEmpty().WithMessage("Options must not be empty")
                .NotNull().WithMessage("Options must not be null");

            RuleFor(x => x.ImageName)
                .MaximumLength(200).WithMessage("ImageName maximum length exceeded")
                .NotEmpty().WithMessage("ImageName must not be empty")
                .NotNull().WithMessage("ImageName must not be null");

            RuleFor(x => x.ImagePath)
                .MaximumLength(200).WithMessage("ImagePath maximum length exceeded")
                .NotEmpty().WithMessage("ImagePath must not be empty")
                .NotNull().WithMessage("ImagePath must not be null");
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
