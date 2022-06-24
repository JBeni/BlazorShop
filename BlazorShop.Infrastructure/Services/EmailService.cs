// <copyright file="EmailService.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.Infrastructure.Services
{
    /// <summary>
    /// An implementation of <see cref="IEmailService"/>.
    /// </summary>
    public class EmailService : IEmailService
    {
        /// <inheritdoc/>
        public async Task SendEmail(string? email, EmailSettings mail)
        {
            using (var client = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = mail.Username,
                    Password = mail.Password
                };

                client.Credentials = credential;
                client.Host = mail.Host;
                client.Port = mail.Port;
                client.EnableSsl = true;

                using var mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress(email));
                mailMessage.From = new MailAddress(mail.Username);
                mailMessage.Subject = mail.Subject;
                mailMessage.Body = mail.Message;
                mailMessage.Priority = MailPriority.High;

                client.Send(mailMessage);
            }
            await Task.CompletedTask;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private static AlternateView AddImageLogo()
        {
            // In text where the image will be placed an cid:image must be set
            AlternateView avHtml = AlternateView.CreateAlternateViewFromString("Email Template", null, MediaTypeNames.Text.Html);
            LinkedResource inline = new("filename.jpg", MediaTypeNames.Image.Jpeg)
            {
                ContentId = Guid.NewGuid().ToString()
            };
            avHtml.LinkedResources.Add(inline);
            Attachment att = new("filePath");
            att.ContentDisposition.Inline = true;
            return avHtml;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private static Attachment Add(Stream attachmentFilename)
        {
            Attachment attachment = new(attachmentFilename, MediaTypeNames.Application.Octet);
            ContentDisposition disposition = attachment.ContentDisposition;

            disposition.CreationDate = File.GetCreationTime(attachmentFilename.ToString());
            disposition.ModificationDate = File.GetLastWriteTime(attachmentFilename.ToString());
            disposition.ReadDate = File.GetLastAccessTime(attachmentFilename.ToString());
            disposition.FileName = Path.GetFileName(attachmentFilename.ToString());
            disposition.Size = new FileInfo(attachmentFilename.ToString()).Length;
            disposition.DispositionType = DispositionTypeNames.Attachment;

            return attachment;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        private static AlternateView GetEmbeddedImage(string? filePath, string? htmlBody)
        {
            LinkedResource res = new(filePath)
            {
                ContentId = "logo"
            };
            AlternateView alternateView = AlternateView.CreateAlternateViewFromString(htmlBody, null, MediaTypeNames.Text.Html);
            alternateView.LinkedResources.Add(res);
            return alternateView;
        }
    }
}
