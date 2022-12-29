// <copyright file="DeleteUserCommand.cs" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    /// <summary>
    /// A model to delete an user.
    /// </summary>
    public class DeleteUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        public int Id { get; set; }
    }
}
