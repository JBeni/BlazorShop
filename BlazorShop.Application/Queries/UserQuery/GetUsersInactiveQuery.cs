// <copyright file="GetUsersInactiveQuery.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.UserQuery
{
    /// <summary>
    /// A model to get the inactive users.
    /// </summary>
    public class GetUsersInactiveQuery : IRequest<Result<UserResponse>>
    {
    }
}
