// <copyright file="StringRoleResources.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Utils
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public static class StringRoleResources
    {
        public const string Admin = "Admin";
        public const string User = "User";
        public const string Default = "Default";

        public const string Customer = "Customer";

        public const string AdminNormalized = "ADMIN";
        public const string UserNormalized = "USER";
        public const string DefaultNormalized = "DEFAULT";

        public const string UserIdClaim = "UserId";
        
        public const string NameClaim = "unique_name";
        public const string NameClaimSecond = "name";

        public const string EmailClaim = "email";
        public const string RoleClaim = "role";
    }
}
