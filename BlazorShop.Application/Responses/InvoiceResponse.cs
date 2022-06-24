// <copyright file="InvoiceResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A model to update a cart.
    /// </summary>
    public class InvoiceResponse : IMapFrom<Invoice>
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AmountSubTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int AmountTotal { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
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
