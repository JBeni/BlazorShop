// <copyright file="ActivateUserCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.UserCommand
{
    public class ActivateUserCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int Id { get; set; }
    }
}
