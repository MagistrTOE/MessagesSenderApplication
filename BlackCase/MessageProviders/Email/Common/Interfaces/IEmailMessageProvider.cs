using MessageProviders.Common.Interfaces;
using MessageProviders.Common.Models;
using MessageProviders.Email.Common.Models;

namespace MessageProviders.Email.Common.Interfaces
{
    /// <summary>
    ///     Email message interface for working with the Provider.
    /// </summary>
    public interface IEmailMessageProvider : IMessageProvider<EmailMessage, MessageReport>
    {
    }
}
