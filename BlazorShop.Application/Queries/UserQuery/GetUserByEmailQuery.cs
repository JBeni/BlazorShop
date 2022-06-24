// <copyright file="GetUserByEmailQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.UserQuery
{
    public class GetUserByEmailQuery : IRequest<Result<UserResponse>>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }
    }
}
