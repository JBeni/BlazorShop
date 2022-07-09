// <copyright file="RequestResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Models
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class RequestResponse
    {
        /// <summary>
        /// .
        /// </summary>
        public bool Successful { get; set; } = false;

        /// <summary>
        /// .
        /// </summary>
        public string? Error { get; set; } = null;

        /// <summary>
        /// .
        /// </summary>
        public int EntityId { get; set; } = 0;

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RequestResponse Success(int id = 0)
        {
            return new RequestResponse { Successful = true, EntityId = id, Error = null };
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="error"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RequestResponse Failure(string error, int id = 0)
        {
            return new RequestResponse { Successful = false, EntityId = id, Error = error };
        }
    }
}
