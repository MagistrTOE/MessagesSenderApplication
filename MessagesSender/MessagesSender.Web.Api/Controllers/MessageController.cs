using MediatR;
using MessagesSender.Application.Features.GetMessages;
using MessagesSender.Application.Features.SendMessage;
using Microsoft.AspNetCore.Mvc;

namespace MessagesSender.Web.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMediator _mediator;

        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("mails")]
        public async Task<List<MessageResponse>> GetMails()
        {
            return await _mediator.Send(new GetMessagesRequest());
        }

        [HttpPost("mails")]
        public async Task<IActionResult> SendMails([FromBody] SendMessageRequest request)
        {
            await _mediator.Send(request);
            
            return Ok();
        }
    }
}
