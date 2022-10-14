using MessagesSender.Domain.Models;

namespace MessagesSender.Domain.Interfaces
{
    /// <summary>
    ///     Message interface for working with the repository.
    /// </summary>
    public interface IMessageRepository
    {
        /// <summary>
        ///     Creates and saves an entity <see cref="Message" /> to the database.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>
        ///     A task that represents the asynchronous  create operation.
        /// </returns>
        Task Create(Message message);

        /// <summary>
        ///     Get messages from database.
        /// </summary>
        /// <returns>
        ///     A task that represents <see cref="List{T}" /> the asynchronous  get operation.
        ///     <remarks>
        ///         <typeparamref name="T"/> is <see cref="Message" />.
        ///     </remarks>
        /// </returns>
        Task<List<Message>> GetMessages();
    }
}
