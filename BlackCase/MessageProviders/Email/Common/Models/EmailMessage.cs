using MessageProviders.Common.Models;

namespace MessageProviders.Email.Common.Models
{
    public class EmailMessage : Message
    {
        /// <summary>
        ///     Email addresses for sending message.
        /// </summary>
        public string[] EmailAddresses { get; set; }
    }
}
