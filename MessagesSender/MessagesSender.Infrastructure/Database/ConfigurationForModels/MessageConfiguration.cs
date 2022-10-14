using MessagesSender.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MessagesSender.Infrastructure.Database.ConfigurationForModels
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder
                .ToTable("Messages");

            builder
                .HasKey(x => x.Id);

            builder
                .Property<DateTime>("CreatedDate")
                .HasColumnType("timestamp");

            builder
                .Property(x => x.FailedMessage).IsRequired(false);
        }
    }
}
