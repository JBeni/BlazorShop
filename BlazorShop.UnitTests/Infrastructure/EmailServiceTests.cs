// <copyright file="EmailServiceTests.cs" company="Beniamin Jitca">
// Copyright (c) Beniamin Jitca. All rights reserved.
// </copyright>

using BlazorShop.Infrastructure.Email;
using Microsoft.Extensions.Logging;
using System.Net.Mail;

namespace BlazorShop.UnitTests.Infrastructure
{
    /// <summary>
    /// Tests for <see cref="EmailService"/>.
    /// </summary>
    public class EmailServiceTests
    {
        private readonly Mock<ILogger<EmailService>> _loggerMock;
        private readonly EmailService _emailService;
        private readonly EmailSettings _validSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailServiceTests"/> class.
        /// </summary>
        public EmailServiceTests()
        {
            _loggerMock = new Mock<ILogger<EmailService>>();
            _validSettings = new EmailSettings
            {
                Host = "smtp.gmail.com",
                Port = 587,
                Username = "example@gmail.com",
                Password = "password",
                Subject = "Test Email",
                Message = "This is a test email."
            };
            _emailService = new EmailService(_loggerMock.Object);
        }

        [Fact]
        public async Task SendEmail_WithValidParameters_SendsEmail()
        {
            // Arrange
            var recipient = "recipient@example.com";

            // Act
            await _emailService.SendEmail(recipient, _validSettings);

            // Assert
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    null,
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        [Fact]
        public async Task SendEmail_WithNullRecipient_ThrowsArgumentException()
        {
            // Arrange
            string recipient = null;

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => _emailService.SendEmail(recipient, _validSettings));
            
            Assert.Contains("recipient", exception.Message);
        }

        [Fact]
        public async Task SendEmail_WithNullSettings_ThrowsArgumentNullException()
        {
            // Arrange
            var recipient = "recipient@example.com";
            EmailSettings settings = null;

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(
                () => _emailService.SendEmail(recipient, settings));
        }

        [Fact]
        public async Task SendEmail_WithInvalidEmail_ThrowsFormatException()
        {
            // Arrange
            var recipient = "invalid-email";

            // Act & Assert
            await Assert.ThrowsAsync<FormatException>(
                () => _emailService.SendEmail(recipient, _validSettings));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public async Task SendEmail_WithEmptyOrWhitespaceRecipient_ThrowsArgumentException(string recipient)
        {
            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                () => _emailService.SendEmail(recipient, _validSettings));
            
            Assert.Contains("recipient", exception.Message);
        }

        [Fact]
        public async Task SendEmail_WithInvalidSmtpSettings_ThrowsSmtpException()
        {
            // Arrange
            var recipient = "recipient@example.com";
            var invalidSettings = new EmailSettings
            {
                Host = "invalid-host",
                Port = 0,
                Username = "",
                Password = "",
                Subject = "Test",
                Message = "Test"
            };

            // Act & Assert
            await Assert.ThrowsAsync<SmtpException>(
                () => _emailService.SendEmail(recipient, invalidSettings));
        }

        [Fact]
        public async Task SendEmail_LogsError_WhenExceptionOccurs()
        {
            // Arrange
            var recipient = "recipient@example.com";
            var invalidSettings = new EmailSettings
            {
                Host = "invalid-host",
                Port = 0
            };

            // Act
            try
            {
                await _emailService.SendEmail(recipient, invalidSettings);
            }
            catch
            {
                // Expected exception
            }

            // Assert
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }
    }
}
