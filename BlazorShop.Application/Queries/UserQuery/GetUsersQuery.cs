// <copyright file="GetUsersQuery.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Queries.UserQuery
{
    /// <summary>
    /// A model to get the users.
    /// </summary>
    public class GetUsersQuery : IRequest<Result<UserResponse>>
    {
    }
}
