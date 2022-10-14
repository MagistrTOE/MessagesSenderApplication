using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MessagesSender.Infrastructure.Database.Extensions
{
    public static class ServiceProviderExtension
    {
        /// <summary>
        ///     Asynchronously applies any pending migrations for the context to the database. Will create the database
        ///     if it does not already exist.
        /// </summary>
        /// <param name="serviceProvider">
        ///     The <see cref="IServiceProvider"/> to add the provider to.
        /// </param>
        /// <returns>
        ///     A task that represents the asynchronous migration operation.
        /// </returns>
        public static async Task UseMigratiosAsync(this IServiceProvider serviceProvider)
        {
            var serviceScope = serviceProvider.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<MessagesSenderContext>();

            if (context == null)
            {
                throw new NullReferenceException(nameof(context));
            }
            
            await context.Database.MigrateAsync(CancellationToken.None);
        }
    }
}
