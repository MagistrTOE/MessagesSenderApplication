using MessageProviders.Email.Common.Models;
using MessageProviders.Email.MailKit;
using Moq;
using NETCore.MailKit.Core;

namespace MessageProviders.Tests.MailKit
{
    public class MailKitProviderTests
    {
        private readonly Mock<IEmailService> _IEmailServiceMock;
        private readonly MailKitProvider _provider;

        public MailKitProviderTests()
        {
            _IEmailServiceMock = new Mock<IEmailService>();
            _provider = new MailKitProvider(_IEmailServiceMock.Object);
        }

        [Fact]
        public async Task SendEmailMessage_Success()
        {
            // Arrange
            _IEmailServiceMock
                .Setup(x => x.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), false, null))
                .Returns(Task.CompletedTask);

            var emailMessage = new EmailMessage()
            {
                Subject = "TestSubject",
                Body = "TestBody",
                EmailAddresses = new[] { "TestEmail1@mail.ru", "TestEmail2@mail.ru" },
            };

            // Act
            var result = await _provider.Send(emailMessage);

            // Assert
            Assert.Equal("OK", result.Result);
            Assert.Null(result.FailedMessage);
            _IEmailServiceMock.Verify(x =>
                x.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), false, null), Times.AtMostOnce);
        }

        [Fact]
        public async Task SendEmailMessage_Failed()
        {
            // Arrange
            _IEmailServiceMock
                .Setup(x => x.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), false, null))
                .ThrowsAsync(new Exception());

            var emailMessage = new EmailMessage()
            {
                Subject = "TestSubject",
                Body = "TestBody",
                EmailAddresses = new[] { "TestEmail1@mail.ru", "TestEmail2@mail.ru" },
            };

            // Act
            var result = await _provider.Send(emailMessage);

            // Assert
            Assert.Equal("Failed", result.Result);
            Assert.NotNull(result.FailedMessage);
            _IEmailServiceMock.Verify(x =>
                x.SendAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), false, null), Times.AtMostOnce);
        }
    }
}
