// <copyright file="DeleteUserCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    public class DeleteUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
