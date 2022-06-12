﻿namespace BlazorShop.Application.Commands.CartCommand
{
    public class CreateCartCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int ClotheId { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public int Amount { get; set; }
    }
}
