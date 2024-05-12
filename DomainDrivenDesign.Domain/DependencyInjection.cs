using FluentEmail.MailKitSmtp;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesign.Domain;
public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services)
    {
        services
            .AddFluentEmail("caglatuncsavas@gmail.com")
            .AddMailKitSender(new SmtpClientOptions()
            {
                Server = "localhost",
                Port = 25
            });
        return services;
    }
}
