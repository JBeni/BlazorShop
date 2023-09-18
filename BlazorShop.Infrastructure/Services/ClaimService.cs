// <copyright file="ClaimService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Application.Commands.ClaimCommand;

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
        public ClaimService(
            UserManager<User> userManager,
            IMapper mapper)
        {
            this.UserManager = userManager;
            this.Mapper = mapper;
        }

        /// <summary>
        /// Gets the instance of <see cref="UserManager{User}"/> to use.
        /// </summary>
        private UserManager<User> UserManager { get; }

        /// <summary>
        /// Gets the instance of <see cref="IMapper"/> to use.
        /// </summary>
        private IMapper Mapper { get; }

        public Task<List<string>> CheckUserClaimsAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> CreateClaimAsync(CreateClaimCommand claim)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> DeleteClaimAsync(int claimId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomClaim> FindClaimByIdAsync(int claimId)
        {
            throw new NotImplementedException();
        }

        public Task<CustomClaim> FindClaimByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public ClaimResponse GetAdminClaim()
        {
            throw new NotImplementedException();
        }

        public ClaimResponse GetClaimById(int id)
        {
            throw new NotImplementedException();
        }

        public ClaimResponse GetClaimByNormalizedName(string normalizedName)
        {
            throw new NotImplementedException();
        }

        public List<ClaimResponse> GetClaims()
        {
            throw new NotImplementedException();
        }

        public List<ClaimResponse> GetClaimsForAdmin()
        {
            throw new NotImplementedException();
        }

        public ClaimResponse GetDefaultClaim()
        {
            throw new NotImplementedException();
        }

        public ClaimResponse GetUserClaim()
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> SetUserClaimAsync(User user, string claimValue)
        {
            throw new NotImplementedException();
        }

        public Task<RequestResponse> UpdateClaimAsync(UpdateClaimCommand claim)
        {
            throw new NotImplementedException();
        }
    }
}
