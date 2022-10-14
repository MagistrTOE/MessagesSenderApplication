namespace MessagesSender.Domain.Models
{
    public class Message
    {
        /// <summary>
        ///     Message id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     Message subject.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        ///     Message body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        ///     Message recipients.
        /// </summary>
        public string[] Recipients { get; set; }

        /// <summary>
        ///     Message created date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        ///     Status of the sent message.
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        ///     Sent message error report.
        /// </summary>
        public string FailedMessage { get; set; }
    }
}
