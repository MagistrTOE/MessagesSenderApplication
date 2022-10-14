using AutoMapper;
using MediatR;
using MessagesSender.Domain.Interfaces;

namespace MessagesSender.Application.Features.GetMessages
{
    public class GetMessagesRequest : IRequest<List<MessageResponse>> 
    {
    }

    public class GetMessagesHandler : IRequestHandler<GetMessagesRequest, List<MessageResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IMessageRepository _messageRepository;

        public GetMessagesHandler(IMapper mapper, IMessageRepository messageRepository)
        {
            _mapper = mapper;
            _messageRepository = messageRepository;
        }

        public async Task<List<MessageResponse>> Handle(GetMessagesRequest request, CancellationToken cancellationToken)
        {
            var messages = await _messageRepository.GetMessages();
            
            return _mapper.Map<List<MessageResponse>>(messages);
        }
    }
}
