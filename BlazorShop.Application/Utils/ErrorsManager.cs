// <copyright file="ErrorsManager.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Utils
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public static class ErrorsManager
    {
        // Commands

        public const string? ChangePasswordCommand = "There was an error changing the password";
        public const string? LoginCommand = "There was an error when the user tried to log in";
        public const string? RegisterCommand = "There was an error when the user tried to register";
        public const string? ResetPasswordCommand = "There was an error resetting the password";

        public const string? CreateCartCommand = "There was an error creating the cart";
        public const string? DeleteAllCartsCommand = "There was an error deleting all the carts";
        public const string? DeleteCartCommand = "There was an error deleting the cart";
        public const string? UpdateCartCommand = "There was an error updating the cart";

        public const string? CreateClotheCommand = "There was an error creating the clothe";
        public const string? DeleteClotheCommand = "There was an error deleting the clothe";
        public const string? UpdateClotheCommand = "There was an error updating the clothe";

        public const string? CreateInvoiceCommand = "There was an error creating the invoice";
        public const string? DeleteInvoiceCommand = "There was an error deleting the invoice";
        public const string? UpdateInvoiceCommand = "There was an error updating the invoice";

        public const string? CreateMusicCommand = "There was an error creating the music";
        public const string? DeleteMusicCommand = "There was an error deleting the music";
        public const string? UpdateMusicCommand = "There was an error updating the music";

        public const string? CreateOrderCommand = "There was an error creating the order";
        public const string? DeleteOrderCommand = "There was an error deleting the order";
        public const string? UpdateOrderCommand = "There was an error updating the order";

        public const string? CreateReceiptCommand = "There was an error creating the receipt";
        public const string? DeleteReceiptCommand = "There was an error deleting the receipt";
        public const string? UpdateReceiptCommand = "There was an error updating the receipt";

        public const string? CreateRoleCommand = "There was an error creating the role";
        public const string? DeleteRoleCommand = "There was an error deleting the role";
        public const string? UpdateRoleCommand = "There was an error updating the role";

        public const string? CreateSubscriberCommand = "There was an error creating the subscriber";
        public const string? DeleteSubscriberCommand = "There was an error deleting the subscriber";
        public const string? UpdateCreatedSubscriberCommand = "There was an error updating the subscriber subscription after creation";
        public const string? UpdateSubscriberCommand = "There was an error updating the subscriber";
        public const string? UpdateSubscriberStatusCommand = "There was an error updating the subscriber status";

        public const string? CreateSubscriptionCommand = "There was an error creating the subscription";
        public const string? DeleteSubscriptionCommand = "There was an error deleting the subscription";
        public const string? UpdateSubscriptionCommand = "There was an error updating the subscription";

        public const string? ActivateUserCommand = "There was an error while activating the user";
        public const string? AssignUserToRoleCommand = "There was an error while assigning the role to user";
        public const string? CreateUserCommand = "There was an error while creating the user";
        public const string? DeleteUserCommand = "There was an error while deleting the user";
        public const string? UpdateUserCommand = "There was an error while updating the user";
        public const string? UpdateUserEmailCommand = "There was an error while updating only the user email";

        public const string? CreateTodoItemCommand = "There was an error while creating the todo item";
        public const string? DeleteTodoItemCommand = "There was an error while deleting the todo item";
        public const string? UpdateTodoItemCommand = "There was an error while updating the todo item";

        public const string? CreateTodoListCommand = "There was an error while creating the todo list";
        public const string? DeleteTodoListCommand = "There was an error while deleting the todo list";
        public const string? UpdateTodoListCommand = "There was an error while updating the todo list";


        // Queries

        public const string? GetCartByIdQuery = "There was an error while getting the cart by id";
        public const string? GetCartsCountQuery = "There was an error getting the carts count";
        public const string? GetCartsQuery = "There was an error while getting the carts";

        public const string? GetClotheByIdQuery = "There was an error while getting the clothe by id";
        public const string? GetClothesQuery = "There was an error while getting the clothes";

        public const string? GetInvoiceByIdQuery = "There was an error while getting the invoice by id";
        public const string? GetInvoicesQuery = "There was an error while getting the invoices";

        public const string? GetMusicByIdQuery = "There was an error while getting the music by id";
        public const string? GetMusicsQuery = "There was an error while getting the musics";

        public const string? GetOrderByIdQuery = "There was an error while getting the order by id";
        public const string? GetOrdersQuery = "There was an error while getting the orders";

        public const string? GetReceiptByIdQuery = "There was an error while getting the receipt by id";
        public const string? GetReceiptsQuery = "There was an error while getting the receipts";

        public const string? GetRoleByIdQuery = "There was an error getting the role by id";
        public const string? GetRoleByNormalizedNameQuery = "There was an error getting the role by normalized name";
        public const string? GetRolesForAdminQuery = "There was an error getting the roles";
        public const string? GetRolesQuery = "There was an error getting the roles";

        public const string? GetSubscriberByIdQuery = "There was an error while getting the subscriber by user id - active subscription";
        public const string? GetSubscribersQuery = "There was an error while getting all the subscribers";
        public const string? GetUserSubscribersQuery = "There was an error while getting the subscribers by user id";

        public const string? GetSubscriptionByIdQuery = "There was an error while getting the subscription by id";
        public const string? GetSubscriptionsQuery = "There was an error while getting the subscriptions";

        public const string? GetUserByEmailQuery = "There was an error getting the user by email";
        public const string? GetUserByIdQuery = "There was an error getting the user by id";
        public const string? GetUsersInactiveQuery = "There was an error getting the inactive users";
        public const string? GetUsersQuery = "There was an error getting the users";

        public const string? GetTodoItemByIdQuery = "There was an error getting the todo item by id";
        public const string? GetTodoItemsQuery = "There was an error getting the todo items";

        public const string? GetTodoListByIdQuery = "There was an error getting the todo list by id";
        public const string? GetTodoListsQuery = "There was an error getting the todo lists";
    }
}
