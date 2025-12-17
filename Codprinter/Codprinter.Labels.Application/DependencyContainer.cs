using Codprinter.Labels.Application.Interfaces.CreateLabel;
using Codprinter.Labels.Application.UsesCases;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Labels.Application;

public static class DependencyContainer
{
    public static IServiceCollection AddLabelUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreateLabelInputPort, CreateLabelInteractor>();

        return services;
    }
}
