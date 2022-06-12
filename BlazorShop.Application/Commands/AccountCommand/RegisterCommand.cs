﻿namespace BlazorShop.Application.Commands.AccountCommand
{
    public class RegisterCommand : IRequest<JwtTokenResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? RoleName { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Password { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? ConfirmPassword { get; set; }
    }
}
