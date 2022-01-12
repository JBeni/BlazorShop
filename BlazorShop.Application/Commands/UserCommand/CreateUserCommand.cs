﻿namespace BlazorShop.Application.Commands.UserCommand
{
    public class CreateUserCommand : IRequest<RequestResponse>
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
    }
}