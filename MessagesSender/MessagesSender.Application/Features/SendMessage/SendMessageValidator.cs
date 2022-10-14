using FluentValidation;

namespace MessagesSender.Application.Features.SendMessage
{
    public class SendMessageValidator : AbstractValidator<SendMessageRequest>
    {
        public SendMessageValidator()
        {
            RuleFor(x => x.Subject)
                .NotEmpty()
                .WithMessage("Enter the subject of the message");

            RuleFor(x => x.Body)
                .NotEmpty()
                .WithMessage("Enter your message");

            RuleFor(x => x.Recipients)
                .Cascade(CascadeMode.Stop)
                .ForEach(x => x.EmailAddress())
                .NotEmpty()
                .WithMessage("Enter the recipient's address");
        }
    }
}
