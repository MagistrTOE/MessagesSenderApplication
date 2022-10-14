using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MessagesSender.Infrastructure.Database
{
    public class MessagesSenderContextFactory : IDesignTimeDbContextFactory<MessagesSenderContext>
    {
        public MessagesSenderContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MessagesSenderContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=password;Host=localhost;Port=5432;Database=MessagesSenderDb;");
            
            return new MessagesSenderContext(optionsBuilder.Options);
        }
    }
}
