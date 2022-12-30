// <copyright file="RequestResponse.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    /// <summary>
    /// A generic model to return the results.
    /// </summary>
    public class RequestResponse
    {
        /// <summary>
        /// Gets or sets A value indicating whether the request was successfully or not.
        /// </summary>
        public bool Successful { get; set; } = false;

        /// <summary>
        /// Gets or sets The error message if the request is not successful.
        /// </summary>
        public string? Error { get; set; } = null;

        /// <summary>
        /// Gets or sets The id of the entity.
        /// </summary>
        public int EntityId { get; set; } = 0;

        /// <summary>
        /// Gets the request response in case of success.
        /// </summary>
        /// <param name="id">The id of the entity.</param>
        /// <returns>A successful response.</returns>
        public static RequestResponse Success(int id = 0)
        {
            return new RequestResponse { Successful = true, EntityId = id, Error = null };
        }

        /// <summary>
        /// Gets the request response in case of failure.
        /// </summary>
        /// <param name="error">The error message.</param>
        /// <param name="id">The id of the entitty.</param>
        /// <returns>A failure response.</returns>
        public static RequestResponse Failure(string error, int id = 0)
        {
            return new RequestResponse { Successful = false, EntityId = id, Error = error };
        }
    }
}
