namespace BlazorShop.Application.Responses
{
    public class InvoiceResponse : IMapFrom<Invoice>
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public int AmountSubTotal { get; set; }
        public int AmountTotal { get; set; }
        public int Quantity { get; set; }

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

        public string? Error { get; set; }
    }
}
