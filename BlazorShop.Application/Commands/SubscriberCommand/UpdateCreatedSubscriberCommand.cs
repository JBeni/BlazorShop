// <copyright file="UpdateCreatedSubscriberCommand.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Commands.SubscriberCommand
{
    public class UpdateCreatedSubscriberCommand : IRequest<RequestResponse>
    {
        /// <summary>
        /// .
        /// </summary>
        public DateTime CurrentPeriodEnd { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public DateTime CurrentPeriodStart { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string StripeSubscriberSubscriptionId { get; set; }

        /// <summary>
        /// .
        /// </summary>
        public string HostedInvoiceUrl { get; set; }
    }
}
