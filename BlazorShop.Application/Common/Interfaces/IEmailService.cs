namespace BlazorShop.Application.Common.Interfaces
{
    public interface IEmailService
    {
        /// <summary>
        /// .
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        Task SendEmail(string? email, EmailSettings mail);
    }
}
