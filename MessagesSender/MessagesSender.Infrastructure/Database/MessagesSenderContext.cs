using MessagesSender.Infrastructure.Database.ConfigurationForModels;
using Microsoft.EntityFrameworkCore;

namespace MessagesSender.Infrastructure.Database
{
    public class MessagesSenderContext : DbContext
    {
        public MessagesSenderContext(DbContextOptions<MessagesSenderContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
        }
    }
}
