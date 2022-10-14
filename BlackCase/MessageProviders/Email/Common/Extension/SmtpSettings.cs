namespace MessageProviders.Email.Common.Extension
{
    public class SmtpSettings
    {
        /// <summary>
        ///     Smtp host.
        /// </summary>
        public string? Host { get; set; }

        /// <summary>
        ///     Smtp port.
        /// </summary>
        public string? Port { get; set; }

        /// <summary>
        ///     Sender name for smtp.
        /// </summary>
        public string? SenderName { get; set; }

        /// <summary>
        ///     Sender email for smtp.
        /// </summary>
        public string? SenderEmail { get; set; }

        /// <summary>
        ///     Account name.
        /// </summary>
        public string? Account { get; set; }

        /// <summary>
        ///     Account password.
        /// </summary>
        public string? Password { get; set; }
    }
}
