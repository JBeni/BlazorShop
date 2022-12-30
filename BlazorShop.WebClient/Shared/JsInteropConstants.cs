// <copyright file="JsInteropConstants.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Shared
{
    /// <summary>
    /// A runtime JS constants.
    /// </summary>
    public static class JsInteropConstants
    {
        /// <summary>
        /// Gets the session storage.
        /// </summary>
        public const string GetSessionStorage = $"{FuncPrefix}.getSessionStorage";

        /// <summary>
        /// Sets the session storage.
        /// </summary>
        public const string SetSessionStorage = $"{FuncPrefix}.setSessionStorage";

        /// <summary>
        /// The modal name.
        /// </summary>
        public const string HideModal = $"{FuncPrefix}.hideModal";

        /// <summary>
        /// The name of the JS runtimes.
        /// </summary>
        private const string FuncPrefix = "BlazorShop";
    }
}
