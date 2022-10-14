using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

namespace MessageProviders.Email.Common.Extension
{
    public static class ServiceCollectionExtension
    {
        /// <summary>
        ///     Adds a MailKit provider service to <see cref="IServiceCollection"/>.
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
        public static IServiceCollection AddMailKitProvider(this IServiceCollection services, IConfiguration configuration)
        {
            var smtpSettings = configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
            services.AddMailKit(optionBuilder =>
            {
                optionBuilder.UseMailKit(new MailKitOptions()
                {
                    Server = smtpSettings.Host,
                    Port = Convert.ToInt32(smtpSettings.Port),
                    SenderName = smtpSettings.SenderName,
                    SenderEmail = smtpSettings.SenderEmail,
                    Account = smtpSettings.Account,
                    Password = smtpSettings.Password,
                    Security = true
                });
            });

            return services;
        }
    }
}
