using MessagesSender.Domain.Interfaces;
using MessagesSender.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessagesSender.Infrastructure.Database.Extensions
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        ///     Adds a Postgresql database service to <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">
        ///     The <see cref="IServiceCollection"/> to add the service to.
        /// </param>
        /// <param name="configuration">
        ///     The <see cref="IConfiguration"/> application properties.
        /// </param>
        /// <returns>
        ///     A reference to this instance after the operation has completed.
        /// </returns>
        public static IServiceCollection AddDatabasePostgreSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MessagesSenderContext>(opt => opt
                .UseNpgsql(configuration.GetConnectionString("MessagesSenderContext")));
            services.AddTransient<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
