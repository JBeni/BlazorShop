// <copyright file="ReceiptResponse.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Application.Responses
{
    /// <summary>
    /// A Receipt response model.
    /// </summary>
    public class ReceiptResponse : IMapFrom<Receipt>
    {
        /// <summary>
        /// Gets or sets The id of the receipt.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets The email of the user.
        /// </summary>
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets The date when the receipt was generated.
        /// </summary>
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// Gets or sets The name of the receipt.
        /// </summary>
        public string ReceiptName { get; set; }

        /// <summary>
        /// Gets or sets The url of the receipt.
        /// </summary>
        public string ReceiptUrl { get; set; }

        /// <summary>
        /// Convert the entity (Data Access Layer) to model (Business Logic Layer).
        /// </summary>
        /// <param name="profile">The profile to use for the mapping operation.</param>
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
