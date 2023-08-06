// <copyright file="IUserService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Interfaces
{
    /// <summary>
    /// A service to provide User features.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Gets the user's roles.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <returns>The list of user's roles.</returns>
        Task<List<string>> GetUserRoleAsync(User user);

        /// <summary>
        /// Gets the active users.
        /// </summary>
        /// <param name="query">The quey object.</param>
        /// <returns>The list of users.</returns>
        List<UserResponse> GetUsers(GetUsersQuery query);

        /// <summary>
        /// Gets the inactive users.
        /// </summary>
        /// <param name="query">The quey object.</param>
        /// <returns>The list of inactive users.</returns>
        List<UserResponse> GetUsersInactive(GetUsersInactiveQuery query);

        /// <summary>
        /// Get the user by id.
        /// </summary>
        /// <param name="query">The quey object.</param>
        /// <returns>The user.</returns>
        UserResponse GetUserById(GetUserByIdQuery query);

        /// <summary>
        /// Gets the user by email.
        /// </summary>
        /// <param name="query">The quey object.</param>
        /// <returns>The user.</returns>
        UserResponse GetUserByEmail(GetUserByEmailQuery query);

        /// <summary>
        /// Find the user by id.
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>The user.</returns>
        Task<User> FindUserByIdAsync(int userId);

        /// <summary>
        /// Find the user by email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns>The user.</returns>
        Task<User> FindUserByEmailAsync(string email);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> CreateUserAsync(CreateUserCommand user);

        /// <summary>
        /// Assign a user to a role.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> AssignUserToRoleAsync(AssignUserToRoleCommand user);

        /// <summary>
        /// Updates a user.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> UpdateUserAsync(UpdateUserCommand user);

        /// <summary>
        /// Activate a user.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> ActivateUserAsync(ActivateUserCommand user);

        /// <summary>
        /// Updates the email address of an user.
        /// </summary>
        /// <param name="user">The user object.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> UpdateUserEmailAsync(UpdateUserEmailCommand user);

        /// <summary>
        /// Deletes an user (soft delete).
        /// </summary>
        /// <param name="userId">The id of the user.</param>
        /// <returns>The request response.</returns>
        Task<RequestResponse> DeleteUserAsync(int userId);

        /// <summary>
        /// Check if a user have a role.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="role">The role name.</param>
        /// <returns>A boolean value.</returns>
        Task<bool> IsInRoleAsync(int userId, string role);

        /// <summary>
        /// Authorize an user based on policy.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="policyName">The policy name.</param>
        /// <returns>A boolean value.</returns>
        Task<bool> AuthorizeAsync(int userId, string policyName);
    }
}
