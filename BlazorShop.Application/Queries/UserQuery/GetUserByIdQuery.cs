// <copyright file="GetUserByIdQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.UserQuery
{
    /// <summary>
    /// A model to get the user.
    /// </summary>
    public class GetUserByIdQuery : IRequest<Result<UserResponse>>
    {
        /// <summary>
        /// Gets or sets The id of the user.
        /// </summary>
        public int Id { get; set; }
    }
}
