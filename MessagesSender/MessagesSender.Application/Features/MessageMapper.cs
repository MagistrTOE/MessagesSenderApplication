using AutoMapper;
using MessageProviders.Email.Common.Models;
using MessagesSender.Application.Features.GetMessages;
using MessagesSender.Application.Features.SendMessage;
using MessagesSender.Domain.Models;

namespace MessagesSender.Application.Features
{
    public class MessageMapper : Profile
    {
        public MessageMapper()
        {
            CreateMap<Message, MessageResponse>();
            CreateMap<SendMessageRequest, EmailMessage>()
                .ForMember(destMember => destMember.EmailAddresses, memberOpt => memberOpt.MapFrom(x => x.Recipients));
        }
    }
}
