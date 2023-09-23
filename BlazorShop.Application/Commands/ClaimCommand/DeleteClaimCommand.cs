// <copyright file="DeleteClaimCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ClaimCommand
{
    /// <summary>
    /// A model to delete a claim.
    /// </summary>
    public class DeleteClaimCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// Gets or sets the id of the claim.
        /// </summary>
        public int Id { get; set; }
    }
}
