using AutoMapper;
using MessagesSender.Application.Features;
using MessagesSender.Application.Features.GetMessages;
using MessagesSender.Domain.Interfaces;
using MessagesSender.Domain.Models;
using Moq;

namespace MessagesSender.Tests.GetMessages
{
    public class GetMessagesHandlerTests
    {
        private readonly Mock<IMessageRepository> _IMessageRepositoryMock;
        private readonly GetMessagesHandler _handler;

        public GetMessagesHandlerTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<MessageMapper>());
            var mapper = new Mapper(mapperConfiguration);

            _IMessageRepositoryMock = new Mock<IMessageRepository>();
            _handler = new GetMessagesHandler(mapper, _IMessageRepositoryMock.Object);
        }

        [Fact]
        public async Task GetMessages()
        {
            // Arrange
            _IMessageRepositoryMock
                .Setup(x => x.GetMessages())
                .ReturnsAsync(new List<Message>()
                {
                    new Message()
                    {
                        Id = It.IsAny<int>(),
                        Subject = "TestSubject",
                        Body = "TestBody",
                        Recipients = new string[] {"TestRecipient"},
                        CreatedDate = It.IsAny<DateTime>(),
                        Result = "TestResult",
                        FailedMessage = "TestFailedMessage"
                    }
                });

            var request = new GetMessagesRequest();

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            //
            Assert.IsType<List<MessageResponse>>(result);

            var resultItem = result.First();
            Assert.Equal("TestSubject", resultItem.Subject);
            Assert.Equal("TestBody", resultItem.Body);
            Assert.Equal("TestRecipient", resultItem.Recipients.First());
            Assert.Equal("TestResult", resultItem.Result);
            Assert.Equal("TestFailedMessage", resultItem.FailedMessage);
        }
    }
}
