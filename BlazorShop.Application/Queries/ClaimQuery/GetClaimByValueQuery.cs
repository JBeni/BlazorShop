// <copyright file="GetClaimByValueQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.ClaimQuery
{
    /// <summary>
    /// A model to get the claim by value.
    /// </summary>
    public class GetClaimByValueQuery : IRequest<Result<ClaimResponse>>
    {
        /// <summary>
        /// Gets or sets the claim value.
        /// </summary>
        public string Value { get; set; }
    }
}
