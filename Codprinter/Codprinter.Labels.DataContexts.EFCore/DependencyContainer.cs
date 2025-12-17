using Codprinter.Labels.DataContexts.EFCore.Services;
using Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces;
using Codprinter.Shared.Infrastructure.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Labels.DataContexts.EFCore
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLabelDataContext(
            this IServiceCollection services,
            IConfiguration configuration,
            Action<DBOptions> configureDBOptions)
        {
            services.Configure(configureDBOptions);
            services.AddScoped<ICodprinterLabelCommandsDataContext, CodprinterLabelCommandsDataContext>();
            services.AddScoped<ILabelTemplateCommandsDataContext, LabelTemplateCommandsDataContext>();
            return services;
        }
    }
}
