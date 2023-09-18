// <copyright file="GetClaimByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.ClaimQuery
{
    /// <summary>
    /// A model to get the claim by id.
    /// </summary>
    public class GetClaimByIdQuery : IRequest<Result<ClaimResponse>>
    {
        /// <summary>
        /// Gets or sets the claim id.
        /// </summary>
        public int Id { get; set; }
    }
}
