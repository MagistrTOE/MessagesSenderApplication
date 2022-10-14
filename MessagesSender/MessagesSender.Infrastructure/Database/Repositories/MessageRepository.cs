using MessagesSender.Domain.Interfaces;
using MessagesSender.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MessagesSender.Infrastructure.Database.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        protected DbContext _dbContext;
        protected DbSet<Message> _dbSet;

        public MessageRepository(MessagesSenderContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<Message>();
        }

        /// <summary>
        ///     Saves all changes  to the database.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous save operation.
        /// </returns>
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        ///     Creates and saves an entity <see cref="Message" /> to the database.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>
        ///     A task that represents the asynchronous  create operation.
        /// </returns>
        public async Task Create(Message message)
        {
            await _dbSet.AddAsync(message);
            await Save();
        }

        /// <summary>
        ///     Get messages from database.
        /// </summary>
        /// <returns>
        ///     A task that represents result <see cref="List{T}" /> the asynchron get operation.
        ///     <remarks>
        ///         <typeparamref name="T"/> is <see cref="Message" />.
        ///     </remarks>
        /// </returns>
        public async Task<List<Message>> GetMessages()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
