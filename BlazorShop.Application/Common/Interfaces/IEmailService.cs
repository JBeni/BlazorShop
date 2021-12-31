namespace BlazorShop.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string? email, EmailSettings mail);
    }
}
