using Codprinter.Labels.Application;
using Codprinter.Labels.DataContexts.EFCore;
using Codprinter.Labels.InterfaceAdapters;
using Codprinter.Shared.Infrastructure;
using Codprinter.Shared.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Labels.IoC;

public static class DependencyContainer
{
        public static IServiceCollection AddLabelServices(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<DBOptions> configureDBOptions)
    {
        services.AddLabelUseCases()
            .AddLabelPresenters()
            .AddLabelDataContext(configuration, configureDBOptions)
            .AddSharedInfrastructure();
        
        return services;
    }
}
