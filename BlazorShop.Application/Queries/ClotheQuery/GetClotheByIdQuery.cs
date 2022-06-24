// <copyright file="GetClotheByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.ClotheQuery
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class GetClotheByIdQuery : IRequest<Result<ClotheResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
