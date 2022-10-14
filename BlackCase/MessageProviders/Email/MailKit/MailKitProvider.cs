using MessageProviders.Common.Models;
using MessageProviders.Email.Common.Interfaces;
using MessageProviders.Email.Common.Models;
using NETCore.MailKit.Core;

namespace MessageProviders.Email.MailKit
{
    public class MailKitProvider : IEmailMessageProvider
    {
        private readonly IEmailService _emailService;

        public MailKitProvider(IEmailService emailService)
        {
            _emailService = emailService;
        }

        /// <summary>
        ///     Asynchronously sends a message and returns a delivery report.
        /// </summary>
        /// <param name="emailMessage">The message to send.</param>
        /// <param name="cancellationToken">Token cancel operation.</param>
        /// <returns>
        ///     A task that represents result <see cref="MessageReport" /> the asynchron operation send.
        /// </returns>
        public async Task<MessageReport> Send(EmailMessage emailMessage, CancellationToken cancellationToken = default)
        {
            var report = new MessageReport();

            try
            {
                var mailTo = string.Join(',', emailMessage.EmailAddresses);

                await _emailService.SendAsync(mailTo, emailMessage.Subject, emailMessage.Body);

                report.Result = "OK";
            }
            catch (Exception ex)
            {
                report.Result = "Failed";
                report.FailedMessage = ex.Message;
            }
            return report;
        }
    }
}
