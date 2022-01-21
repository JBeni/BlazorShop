namespace BlazorShop.Application.Responses
{
    public class ReceiptResponse : IMapFrom<Receipt>
    {
        public int Id { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string ReceiptName { get; set; }
        public string ReceiptUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Receipt, ReceiptResponse>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.ReceiptDate, opt => opt.MapFrom(s => s.ReceiptDate))
                .ForMember(d => d.ReceiptName, opt => opt.MapFrom(s => s.ReceiptName))
                .ForMember(d => d.ReceiptUrl, opt => opt.MapFrom(s => s.ReceiptUrl));
        }

        public string? Error { get; set; }
    }
}
