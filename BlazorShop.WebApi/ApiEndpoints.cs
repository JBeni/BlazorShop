// <copyright file="ApiEndpoints.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.WebApi
{
    /// <summary>
    /// Defining the Api Endpoints.
    /// </summary>
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";

        /// <summary>
        /// Defines the Accounts Endpoints.
        /// </summary>
        public static class Accounts
        {
            private const string Base = $"{ApiBase}/accounts";

            public const string Login = $"{Base}/login";
            public const string Register = $"{Base}/register";
            public const string ChangePassword = $"{Base}/change-password";
            public const string ResetPassword = $"{Base}/reset-password";
        }

        public static class Carts
        {
            private const string Base = $"{ApiBase}/carts";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}/{{userId:int}}";
            public const string DeleteAll = $"{Base}/{{userId:int}}";
            public const string GetCart = $"{Base}/{{id:int}}/{{userId:int}}";
            public const string GetUserCarts = $"{Base}/{{userId:int}}";
            public const string GetUserCartCount = $"{Base}/{{userId:int}}";
        }

        public static class Clothes
        {
            private const string Base = $"{ApiBase}/clothes";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = $"{Base}";
        }

        public static class Home
        {
            private const string Base = $"{ApiBase}/home";

            public const string HomePage = $"{Base}";
            public const string ErrorPage = $"{Base}/error";
        }

        public static class Invoices
        {
            private const string Base = $"{ApiBase}/invoices";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = $"{Base}";
        }

        public static class Musics
        {
            private const string Base = $"{ApiBase}/musics";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = $"{Base}";
        }

        public static class OidcConfiguration
        {
            private const string Base = $"{ApiBase}/oidc-configuration";

            public const string Get = $"{Base}/_configuration/{{clientId:int}}";
        }

        public static class Orders
        {
            private const string Base = $"{ApiBase}/orders";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}/{{userEmail:string}}";
            public const string GetAll = $"{Base}/{{userEmail:string}}";
        }

        public static class Payments
        {
            private const string Base = $"{ApiBase}/payments";

            public const string CreateSubscription = $"{Base}/create-subscriptio";
            public const string CancelSubscription = $"{Base}/cancel-subscription/{{stripeSubscriptionCreationId:string}}";
            public const string UpdateSubscription = $"{Base}/update-subscription";
            public const string Checkout = $"{Base}/checkout";
            public const string WebHook = $"{Base}/webhook";
        }

        public static class Receipts
        {
            private const string Base = $"{ApiBase}/receipts";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}/{{userEmail:string}}";
            public const string GetAll = $"{Base}/{{userEmail:string}}";
        }

        public static class Roles
        {
            private const string Base = $"{ApiBase}/roles";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = $"{Base}";
            public const string GetAllForAdmin = $"{Base}/rolesAdmin";
        }

        public static class Subscribers
        {
            private const string Base = $"{ApiBase}/subscribers";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetUser = $"{Base}/{{userId:int}}";
        }

        public static class Subscriptions
        {
            private const string Base = $"{ApiBase}/subscriptions";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = $"{Base}";
        }

        public static class TodoItems
        {
            private const string Base = $"{ApiBase}/todo-items";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}";
        }

        public static class TodoLists
        {
            private const string Base = $"{ApiBase}/todo-lists";

            public const string Create = $"{Base}";
            public const string Update = $"{Base}/{{id:int}}";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetAll = $"{Base}";
        }

        public static class Users
        {
            private const string Base = $"{ApiBase}/users";

            public const string Create = $"{Base}";
            public const string Activate = $"{Base}/userActivate";
            public const string Update = $"{Base}/{{id:int}}";
            public const string UpdateEmail = $"{Base}/userEmail";
            public const string Delete = $"{Base}/{{id:int}}";
            public const string Get = $"{Base}/{{id:int}}";
            public const string GetUsers = $"{Base}";
            public const string GetInactiveUsers = $"{Base}/usersInactive";
        }
    }
}
