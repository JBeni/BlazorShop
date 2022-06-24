// <copyright file="JsInteropConstants.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebClient.Shared
{
    public static class JsInteropConstants
    {
        private const string FuncPrefix = "BlazorShop";

        public const string GetSessionStorage = $"{FuncPrefix}.getSessionStorage";

        public const string SetSessionStorage = $"{FuncPrefix}.setSessionStorage";

        public const string HideModal = $"{FuncPrefix}.hideModal";
    }
}
