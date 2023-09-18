// <copyright file="UpdateClaimCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ClaimCommand
{
    /// <summary>
    /// A model to update a claim.
    /// </summary>
    public class UpdateClaimCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets the id of the claim.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the value of the claim.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets the type of the claim.
        /// </summary>
        public string Type { get; set; }
    }
}
