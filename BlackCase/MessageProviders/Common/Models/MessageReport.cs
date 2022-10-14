namespace MessageProviders.Common.Models
{
    public class MessageReport
    {
        /// <summary>
        ///     Status of the sent message.
        /// </summary>
        public string? Result { get; set; }

        /// <summary>
        ///     Sent message error report.
        /// </summary>
        public string? FailedMessage { get; set; }
    }
}
