// <copyright file="ForbiddenAccessException.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Common.Exceptions
{
    /// <summary>
    /// An exception type for forbidden acces.
    /// </summary>
    public class ForbiddenAccessException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ForbiddenAccessException"/> class.
        /// </summary>
        public ForbiddenAccessException()
            : base()
        {
        }
    }
}
