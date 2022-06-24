// <copyright file="GetCartsCountQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.CartQuery
{
    public class GetCartsCountQuery : IRequest<int>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}
