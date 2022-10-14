using MessageProviders.Common.Models;

namespace MessageProviders.Common.Interfaces
{
    /// <summary>
    ///     Message interface for working with the Provider.
    /// </summary>
    /// <typeparam name="TMessage">
    ///     The type of send message.
    /// </typeparam>
    /// <typeparam name="TReport">
    ///     Send message report type.
    ///     </typeparam>
    public interface IMessageProvider<TMessage, TReport> where TMessage : Message where TReport : MessageReport
    {
        /// <summary>
        ///     Asynchronously sends a message and returns a delivery report.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <param name="cancellationToken">Token cancel operation.</param>
        /// <returns>
        ///     A task that represents <see cref="TReport" /> the asynchronous send operation.
        /// </returns>
        Task<TReport> Send(TMessage message, CancellationToken cancellationToken = default);
    }
}
