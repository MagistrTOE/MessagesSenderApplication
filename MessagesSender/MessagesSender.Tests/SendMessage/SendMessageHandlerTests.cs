using AutoMapper;
using MessageProviders.Common.Models;
using MessageProviders.Email.Common.Interfaces;
using MessageProviders.Email.Common.Models;
using MessagesSender.Application.Features;
using MessagesSender.Application.Features.SendMessage;
using MessagesSender.Domain.Interfaces;
using MessageEntity = MessagesSender.Domain.Models.Message;
using Moq;
using MediatR;

namespace MessagesSender.Tests.SendMessage
{
    public class SendMessageHandlerTests
    {
        private readonly Mock<IEmailMessageProvider> _IEmailMessageProviderMock;
        private readonly Mock<IMessageRepository> _IMessageRepositoryMock;
        private readonly SendMessageHandler _handler;

        public SendMessageHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<MessageMapper>());
            var mapper = new Mapper(mapperConfiguration);

            _IEmailMessageProviderMock = new Mock<IEmailMessageProvider>();
            _IMessageRepositoryMock = new Mock<IMessageRepository>();
            _handler = new SendMessageHandler(mapper, _IEmailMessageProviderMock.Object, _IMessageRepositoryMock.Object);
        }

        [Fact]
        public async Task SendMessage()
        {
            // Arrange
            _IEmailMessageProviderMock
                .Setup(x => x.Send(It.IsAny<EmailMessage>(), CancellationToken.None))
                .ReturnsAsync(new MessageReport());

            _IMessageRepositoryMock
                .Setup(x => x.Create(It.IsAny<MessageEntity>()));

            var request = new SendMessageRequest();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.IsType<Unit>(result);
            _IEmailMessageProviderMock.Verify(x => x.Send(It.IsAny<EmailMessage>(), CancellationToken.None), Times.AtMostOnce);
            _IMessageRepositoryMock.Verify(x => x.Create(It.IsAny<MessageEntity>()), Times.AtMostOnce);
        }
    }
}
