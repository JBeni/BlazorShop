// <copyright file="CreateClaimCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.ClaimCommand
{
    /// <summary>
    /// A model to create a claim.
    /// </summary>
    public class CreateClaimCommand : IRequest<RequestResponse>
    {
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
