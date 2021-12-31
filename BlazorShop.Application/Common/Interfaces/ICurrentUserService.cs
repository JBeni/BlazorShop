namespace BlazorShop.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
        string? Username { get; }
    }
}
