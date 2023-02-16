// <copyright file="EmailServiceTests.cs" company="Beniamin Jitca" author="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="EmailService"/>.
    /// </summary>
    public class EmailServiceTests
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailServiceTests"/> class.
        /// </summary>
        public EmailServiceTests()
        {
        }

        /// <summary>
        /// Gets the instance of <see cref="IEmailService"/> to use.
        /// </summary>
        private IEmailService EmailService { get; } = Mock.Of<IEmailService>();

        /// <summary>
        /// A test for <see cref="EmailService.SendEmail(string?, EmailSettings)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task SendEmail_Success()
        {
            var mailSettings = Mock.Of<EmailSettings>(x =>
                x.Host == "smtp.gmail.com" &&
                x.Port == 587 &&
                x.Username == "example@gmail.com" &&
                x.Password == "password" &&
                x.Subject == "Test Email" &&
                x.Message == "This is a test email.");

            await this.EmailService.SendEmail("recipient@example.com", mailSettings);
        }

        /// <summary>
        /// A test for <see cref="EmailService.SendEmail(string?, EmailSettings)"/> method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [Fact]
        public async Task SendEmail_NullRecipient_ThrowsArgumentNullException()
        {
            var mailSettings = Mock.Of<EmailSettings>();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            Assert.ThrowsAsync<ArgumentException>(async () => await this.EmailService.SendEmail(null, mailSettings));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            await Task.CompletedTask;
        }
    }
}
