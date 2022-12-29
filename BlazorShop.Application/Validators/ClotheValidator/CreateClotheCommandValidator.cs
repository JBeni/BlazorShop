// <copyright file="CreateClotheCommandValidator.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Validators.ClotheValidator
{
    /// <summary>
    /// An implementation of the <see cref="AbstractValidator{CreateClotheCommand}"/>.
    /// </summary>
    public class CreateClotheCommandValidator : AbstractValidator<CreateClotheCommand>
    {
        private readonly IApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateClotheCommandValidator"/> class.
        /// </summary>
        /// <param name="context">An instance of <see cref="IApplicationDbContext"/>.</param>
        public CreateClotheCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            _ = RuleFor(v => v.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be null")
                .MaximumLength(200).WithMessage("Name must not exceed 200 characters.")
                .MustAsync(HaveUniqueName).WithMessage("The name already exists.");

            _ = RuleFor(v => v.Description)
                .MaximumLength(1000).WithMessage("Description maximum length exceeded")
                .NotEmpty().WithMessage("Description must not be empty")
                .NotNull().WithMessage("Description must not be null");

            _ = RuleFor(v => v.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            _ = RuleFor(v => v.Amount)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            _ = RuleFor(v => v.ImageName)
                .MaximumLength(200).WithMessage("ImageName maximum length exceeded")
                .NotEmpty().WithMessage("ImageName must not be empty")
                .NotNull().WithMessage("ImageName must not be null");

            _ = RuleFor(v => v.ImagePath)
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
            return await _context.Clothes
                .TagWith(nameof(HaveUniqueName))
                .AllAsync(l => l.Name != name, cancellationToken);
        }
    }
}
