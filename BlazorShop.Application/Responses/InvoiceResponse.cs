// <copyright file="InvoiceResponse.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// An Invoice response model.
    /// </summary>
    public class InvoiceResponse : IMapFrom<Invoice>
    {
        /// <summary>
        /// Gets or sets The id of the invoice.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets The name of the invoice.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets The sub total amount of the invoice.
        /// </summary>
        public int AmountSubTotal { get; set; }

        /// <summary>
        /// Gets or sets The total amount of the invoice.
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// Gets or sets The quantity of the order.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Invoice, InvoiceResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.UserEmail, opt => opt.MapFrom(s => s.UserEmail))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.AmountSubTotal, opt => opt.MapFrom(s => s.AmountSubTotal))
                .ForMember(d => d.AmountTotal, opt => opt.MapFrom(s => s.AmountTotal))
                .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Quantity));
        }
    }
}
