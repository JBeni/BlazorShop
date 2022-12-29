// <copyright file="GetCartsCountQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.CartQuery
{
    /// <summary>
    /// A model to count the carts.
    /// </summary>
    public class GetCartsCountQuery : IRequest<int>
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        public int UserId { get; set; }
    }
}
