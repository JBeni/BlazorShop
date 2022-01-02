namespace BlazorShop.Application.Commands.AppRoleCommand
{
    public class UpdateRoleCommand : IRequest<RequestResponse>
    {
        public int Id { get; set; }
        public string? OldName { get; set; }
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
    }
}
