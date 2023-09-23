// <copyright file="ClaimService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Services
{
    /// <summary>
    /// An implementation of <see cref="IClaimService"/>.
    /// </summary>
    public class ClaimService : IClaimService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaimService"/> class.
        /// </summary>
        /// <param name="userManager">The instance of <see cref="UserManager{User}"/> to use.</param>
        /// <param name="mapper">The instance of <see cref="IMapper"/> to use.</param>
        /// <param name="dbContext">The instance of <see cref="IApplicationDbContext"/> to use.</param>
        public ClaimService(
            UserManager<User> userManager,
            IMapper mapper,
            IApplicationDbContext dbContext)
        {
            this.UserManager = userManager;
            this.Mapper = mapper;
            this.DbContext = dbContext;
        }

        /// <summary>
        /// Gets the instance of <see cref="UserManager{User}"/> to use.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; }

        /// <summary>
        /// Gets the instance of <see cref="IApplicationDbContext"/> to use.
        /// </summary>
        private IApplicationDbContext DbContext { get; }

        /// <inheritdoc/>
        public Task<List<string>> CheckUserClaimsAsync(User user)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<RequestResponse> CreateClaimAsync(CreateClaimCommand claim)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<RequestResponse> DeleteClaimAsync(int claimId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public ClaimResponse GetClaimById(int id)
        {
            var result = this.DbContext.CustomClaims
                .TagWith(nameof(this.GetClaimById))
                .ProjectTo<ClaimResponse>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault(c => c.Id == id);
            return result;
        }

        /// <inheritdoc/>
        public ClaimResponse GetClaimByValue(string claimValue)
        {
            var result = this.DbContext.CustomClaims
                .TagWith(nameof(this.GetClaimById))
                .ProjectTo<ClaimResponse>(this.Mapper.ConfigurationProvider)
                .FirstOrDefault(c => c.Value.Equals(claimValue, StringComparison.OrdinalIgnoreCase));
            return result;
        }

        /// <inheritdoc/>
        public List<ClaimResponse> GetClaims()
        {
            var result = this.DbContext.CustomClaims
                .TagWith(nameof(this.GetClaims))
                .ProjectTo<ClaimResponse>(this.Mapper.ConfigurationProvider)
                .ToList();
            return result;
        }

        /// <inheritdoc/>
        public ClaimResponse GetUserClaim()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<RequestResponse> SetUserClaimAsync(User user, string claimValue)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public Task<RequestResponse> UpdateClaimAsync(UpdateClaimCommand claim)
        {
            throw new NotImplementedException();
        }
    }
}
