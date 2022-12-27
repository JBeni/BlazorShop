// <copyright file="JsInteropConstants.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Shared
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public static class JsInteropConstants
    {
        /// <summary>
        /// .
        /// </summary>
        private const string FuncPrefix = "BlazorShop";

        /// <summary>
        /// .
        /// </summary>
        public const string GetSessionStorage = $"{FuncPrefix}.getSessionStorage";

        /// <summary>
        /// .
        /// </summary>
        public const string SetSessionStorage = $"{FuncPrefix}.setSessionStorage";

        /// <summary>
        /// .
        /// </summary>
        public const string HideModal = $"{FuncPrefix}.hideModal";
    }
}
