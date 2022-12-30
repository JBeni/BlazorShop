// <copyright file="ErrorsManager.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Utils
{
    /// <summary>
    /// An Error Messages Manager.
    /// </summary>
    public static class ErrorsManager
    {
        // Commands

        /// <summary>
        /// The error message for changing the password.
        /// </summary>
        public const string? ChangePasswordCommand = "There was an error changing the password";

        /// <summary>
        /// The error message for login.
        /// </summary>
        public const string? LoginCommand = "There was an error when the user tried to log in";

        /// <summary>
        /// The error message for register.
        /// </summary>
        public const string? RegisterCommand = "There was an error when the user tried to register";

        /// <summary>
        /// The error message of reset password.
        /// </summary>
        public const string? ResetPasswordCommand = "There was an error resetting the password";

        /// <summary>
        /// The error message for creating the cart.
        /// </summary>
        public const string? CreateCartCommand = "There was an error creating the cart";

        /// <summary>
        /// The error message for deleting all the carts.
        /// </summary>
        public const string? DeleteAllCartsCommand = "There was an error deleting all the carts";

        /// <summary>
        /// The error message for deleting a cart.
        /// </summary>
        public const string? DeleteCartCommand = "There was an error deleting the cart";

        /// <summary>
        /// The error message for updating the cart.
        /// </summary>
        public const string? UpdateCartCommand = "There was an error updating the cart";

        /// <summary>
        /// The error message for creating the clothe.
        /// </summary>
        public const string? CreateClotheCommand = "There was an error creating the clothe";

        /// <summary>
        /// The error message for deleting the clothe.
        /// </summary>
        public const string? DeleteClotheCommand = "There was an error deleting the clothe";

        /// <summary>
        /// The error message for updating the clothe.
        /// </summary>
        public const string? UpdateClotheCommand = "There was an error updating the clothe";

        /// <summary>
        /// The error message for creating the invoice.
        /// </summary>
        public const string? CreateInvoiceCommand = "There was an error creating the invoice";

        /// <summary>
        /// The error message for deleting the invoice.
        /// </summary>
        public const string? DeleteInvoiceCommand = "There was an error deleting the invoice";

        /// <summary>
        /// The error message for updating the invoice.
        /// </summary>
        public const string? UpdateInvoiceCommand = "There was an error updating the invoice";

        /// <summary>
        /// The error message for creating the music.
        /// </summary>
        public const string? CreateMusicCommand = "There was an error creating the music";

        /// <summary>
        /// The error message for deleting the music.
        /// </summary>
        public const string? DeleteMusicCommand = "There was an error deleting the music";

        /// <summary>
        /// The error message for updating the music.
        /// </summary>
        public const string? UpdateMusicCommand = "There was an error updating the music";

        /// <summary>
        /// The error message for creating the order.
        /// </summary>
        public const string? CreateOrderCommand = "There was an error creating the order";

        /// <summary>
        /// The error message for deleting the order.
        /// </summary>
        public const string? DeleteOrderCommand = "There was an error deleting the order";

        /// <summary>
        /// The error message for updating the order.
        /// </summary>
        public const string? UpdateOrderCommand = "There was an error updating the order";

        /// <summary>
        /// The error message for creating the receipt.
        /// </summary>
        public const string? CreateReceiptCommand = "There was an error creating the receipt";

        /// <summary>
        /// The error message for deleting the receipt.
        /// </summary>
        public const string? DeleteReceiptCommand = "There was an error deleting the receipt";

        /// <summary>
        /// The error message for updating the receipt.
        /// </summary>
        public const string? UpdateReceiptCommand = "There was an error updating the receipt";

        /// <summary>
        /// The error message for creating the role.
        /// </summary>
        public const string? CreateRoleCommand = "There was an error creating the role";

        /// <summary>
        /// The error message for deleting the role.
        /// </summary>
        public const string? DeleteRoleCommand = "There was an error deleting the role";

        /// <summary>
        /// The error message for updating the role.
        /// </summary>
        public const string? UpdateRoleCommand = "There was an error updating the role";

        /// <summary>
        /// The error message for creating the subscriber.
        /// </summary>
        public const string? CreateSubscriberCommand = "There was an error creating the subscriber";

        /// <summary>
        /// The error message for deleting the subscriber.
        /// </summary>
        public const string? DeleteSubscriberCommand = "There was an error deleting the subscriber";

        /// <summary>
        /// The error message for updating the created subscriber.
        /// </summary>
        public const string? UpdateCreatedSubscriberCommand = "There was an error updating the subscriber subscription after creation";

        /// <summary>
        /// The error message for updating the subscriber.
        /// </summary>
        public const string? UpdateSubscriberCommand = "There was an error updating the subscriber";

        /// <summary>
        /// The error message for updating the subscriber status.
        /// </summary>
        public const string? UpdateSubscriberStatusCommand = "There was an error updating the subscriber status";

        /// <summary>
        /// The error message for creating the subscription.
        /// </summary>
        public const string? CreateSubscriptionCommand = "There was an error creating the subscription";

        /// <summary>
        /// The error message for deleting the subscription.
        /// </summary>
        public const string? DeleteSubscriptionCommand = "There was an error deleting the subscription";

        /// <summary>
        /// The error message for updating the subscription.
        /// </summary>
        public const string? UpdateSubscriptionCommand = "There was an error updating the subscription";

        /// <summary>
        /// The error message for activating the user.
        /// </summary>
        public const string? ActivateUserCommand = "There was an error while activating the user";

        /// <summary>
        /// The error message for assigning the user.
        /// </summary>
        public const string? AssignUserToRoleCommand = "There was an error while assigning the role to user";

        /// <summary>
        /// The error message for creating the user.
        /// </summary>
        public const string? CreateUserCommand = "There was an error while creating the user";

        /// <summary>
        /// The error message for deleting the user.
        /// </summary>
        public const string? DeleteUserCommand = "There was an error while deleting the user";

        /// <summary>
        /// The error message for updating the user.
        /// </summary>
        public const string? UpdateUserCommand = "There was an error while updating the user";

        /// <summary>
        /// The error message for updating the email of user.
        /// </summary>
        public const string? UpdateUserEmailCommand = "There was an error while updating only the user email";

        /// <summary>
        /// The error message for creating the item.
        /// </summary>
        public const string? CreateTodoItemCommand = "There was an error while creating the todo item";

        /// <summary>
        /// The error message for deleting the item.
        /// </summary>
        public const string? DeleteTodoItemCommand = "There was an error while deleting the todo item";

        /// <summary>
        /// The error message for updating the item.
        /// </summary>
        public const string? UpdateTodoItemCommand = "There was an error while updating the todo item";

        /// <summary>
        /// The error message for creating the list.
        /// </summary>
        public const string? CreateTodoListCommand = "There was an error while creating the todo list";

        /// <summary>
        /// The error message for deleting the list.
        /// </summary>
        public const string? DeleteTodoListCommand = "There was an error while deleting the todo list";

        /// <summary>
        /// The error message for updating the list.
        /// </summary>
        public const string? UpdateTodoListCommand = "There was an error while updating the todo list";

        // Queries

        /// <summary>
        /// The error message for GetCartByIdQuery.
        /// </summary>
        public const string? GetCartByIdQuery = "There was an error while getting the cart by id";

        /// <summary>
        /// The error message for GetCartsCountQuery.
        /// </summary>
        public const string? GetCartsCountQuery = "There was an error getting the carts count";

        /// <summary>
        /// The error message for GetCartsQuery.
        /// </summary>
        public const string? GetCartsQuery = "There was an error while getting the carts";

        /// <summary>
        /// The error message for GetClotheByIdQuery.
        /// </summary>
        public const string? GetClotheByIdQuery = "There was an error while getting the clothe by id";

        /// <summary>
        /// The error message for GetClothesQuery.
        /// </summary>
        public const string? GetClothesQuery = "There was an error while getting the clothes";

        /// <summary>
        /// The error message for GetInvoiceByIdQuery.
        /// </summary>
        public const string? GetInvoiceByIdQuery = "There was an error while getting the invoice by id";

        /// <summary>
        /// The error message for GetInvoicesQuery.
        /// </summary>
        public const string? GetInvoicesQuery = "There was an error while getting the invoices";

        /// <summary>
        /// The error message for GetMusicByIdQuery.
        /// </summary>
        public const string? GetMusicByIdQuery = "There was an error while getting the music by id";

        /// <summary>
        /// The error message for GetMusicsQuery.
        /// </summary>
        public const string? GetMusicsQuery = "There was an error while getting the musics";

        /// <summary>
        /// The error message for GetOrderByIdQuery.
        /// </summary>
        public const string? GetOrderByIdQuery = "There was an error while getting the order by id";

        /// <summary>
        /// The error message for GetOrdersQuery.
        /// </summary>
        public const string? GetOrdersQuery = "There was an error while getting the orders";

        /// <summary>
        /// The error message for GetReceiptByIdQuery.
        /// </summary>
        public const string? GetReceiptByIdQuery = "There was an error while getting the receipt by id";

        /// <summary>
        /// The error message for GetReceiptsQuery.
        /// </summary>
        public const string? GetReceiptsQuery = "There was an error while getting the receipts";

        /// <summary>
        /// The error message for GetRoleByIdQuery.
        /// </summary>
        public const string? GetRoleByIdQuery = "There was an error getting the role by id";

        /// <summary>
        /// The error message for GetRoleByNormalizedNameQuery.
        /// </summary>
        public const string? GetRoleByNormalizedNameQuery = "There was an error getting the role by normalized name";

        /// <summary>
        /// The error message for GetRolesForAdminQuery.
        /// </summary>
        public const string? GetRolesForAdminQuery = "There was an error getting the roles";

        /// <summary>
        /// The error message for GetRolesQuery.
        /// </summary>
        public const string? GetRolesQuery = "There was an error getting the roles";

        /// <summary>
        /// The error message for GetSubscriberByIdQuery.
        /// </summary>
        public const string? GetSubscriberByIdQuery = "There was an error while getting the subscriber by user id - active subscription";

        /// <summary>
        /// The error message for GetSubscribersQuery.
        /// </summary>
        public const string? GetSubscribersQuery = "There was an error while getting all the subscribers";

        /// <summary>
        /// The error message for GetUserSubscribersQuery.
        /// </summary>
        public const string? GetUserSubscribersQuery = "There was an error while getting the subscribers by user id";

        /// <summary>
        /// The error message for GetSubscriptionByIdQuery.
        /// </summary>
        public const string? GetSubscriptionByIdQuery = "There was an error while getting the subscription by id";

        /// <summary>
        /// The error message for GetSubscriptionsQuery.
        /// </summary>
        public const string? GetSubscriptionsQuery = "There was an error while getting the subscriptions";

        /// <summary>
        /// The error message for GetUserByEmailQuery.
        /// </summary>
        public const string? GetUserByEmailQuery = "There was an error getting the user by email";

        /// <summary>
        /// The error message for GetUserByIdQuery.
        /// </summary>
        public const string? GetUserByIdQuery = "There was an error getting the user by id";

        /// <summary>
        /// The error message for GetUsersInactiveQuery.
        /// </summary>
        public const string? GetUsersInactiveQuery = "There was an error getting the inactive users";

        /// <summary>
        /// The error message for GetUsersQuery.
        /// </summary>
        public const string? GetUsersQuery = "There was an error getting the users";

        /// <summary>
        /// The error message for GetTodoItemByIdQuery.
        /// </summary>
        public const string? GetTodoItemByIdQuery = "There was an error getting the todo item by id";

        /// <summary>
        /// The error message for GetTodoItemsQuery.
        /// </summary>
        public const string? GetTodoItemsQuery = "There was an error getting the todo items";

        /// <summary>
        /// The error message for GetTodoListByIdQuery.
        /// </summary>
        public const string? GetTodoListByIdQuery = "There was an error getting the todo list by id";

        /// <summary>
        /// The error message for GetTodoListsQuery.
        /// </summary>
        public const string? GetTodoListsQuery = "There was an error getting the todo lists";
    }
}
