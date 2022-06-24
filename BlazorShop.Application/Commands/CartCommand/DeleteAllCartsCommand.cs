// <copyright file="DeleteAllCartsCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.CartCommand
{
    public class DeleteAllCartsCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }
    }
}
