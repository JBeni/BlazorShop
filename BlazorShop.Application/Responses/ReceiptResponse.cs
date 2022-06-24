// <copyright file="ReceiptResponse.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    public class ReceiptResponse : IMapFrom<Receipt>
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
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReceiptName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ReceiptUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Receipt, ReceiptResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.UserEmail, opt => opt.MapFrom(s => s.UserEmail))
                .ForMember(d => d.ReceiptDate, opt => opt.MapFrom(s => s.ReceiptDate))
                .ForMember(d => d.ReceiptName, opt => opt.MapFrom(s => s.ReceiptName))
                .ForMember(d => d.ReceiptUrl, opt => opt.MapFrom(s => s.ReceiptUrl));
        }
    }
}
