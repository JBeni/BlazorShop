// <copyright file="GetUserByEmailQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.UserQuery
{
    /// <summary>
    /// A model to get the user.
    /// </summary>
    public class GetUserByEmailQuery : IRequest<Result<UserResponse>>
    {
        /// <summary>
        /// The email of the user.
        /// </summary>
        public string? Email { get; set; }
    }
}
