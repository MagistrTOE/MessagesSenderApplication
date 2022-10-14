using AutoMapper;
using MediatR;
using MessageProviders.Email.Common.Interfaces;
using MessageProviders.Email.Common.Models;
using MessagesSender.Domain.Interfaces;
using MessagesSender.Domain.Models;

namespace MessagesSender.Application.Features.SendMessage
{
    public class SendMessageRequest : IRequest
    {
        /// <summary>
        ///     Mapping message subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///     Mapping message body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     Mapping message recipients.
        /// </summary>
        public string[] Recipients { get; set; }
    }

    public class SendMessageHandler : IRequestHandler<SendMessageRequest>
    {
        private readonly IMapper _mapper;
        private readonly IEmailMessageProvider _emailMessageProvider;
        private readonly IMessageRepository _messageRepository;

        public SendMessageHandler(IMapper mapper, IEmailMessageProvider emailMessageProvider, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _emailMessageProvider = emailMessageProvider;
            _messageRepository = messageRepository;
        }

        public async Task<Unit> Handle(SendMessageRequest request, CancellationToken cancellationToken)
        {
            var emailMessage = _mapper.Map<EmailMessage>(request);

            var messageReport = await _emailMessageProvider.Send(emailMessage, cancellationToken);

            var message = new Message()
            {
                Subject = emailMessage.Subject,
                Body = emailMessage.Body,
                Recipients = emailMessage.EmailAddresses,
                CreatedDate = DateTime.Now,
                Result = messageReport.Result,
                FailedMessage = messageReport.FailedMessage
            };

            await _messageRepository.Create(message);

            return Unit.Value;
        }
    }
}
