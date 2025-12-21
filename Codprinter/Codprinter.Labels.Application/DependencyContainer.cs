using Codprinter.Labels.Application.Interfaces.CreateLabel;
using Codprinter.Labels.Application.Interfaces.DeleteLabel;
using Codprinter.Labels.Application.Interfaces.GetAllLabels;
using Codprinter.Labels.Application.Interfaces.GetLabel;
using Codprinter.Labels.Application.Interfaces.UpdateLabel;
using Codprinter.Labels.Application.UsesCases;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Labels.Application;

public static class DependencyContainer
{
    public static IServiceCollection AddLabelUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreateLabelInputPort, CreateLabelInteractor>();
        services.AddScoped<IGetLabelInputPort, GetLabelInteractor>();
        services.AddScoped<IGetAllLabelsInputPort, GetAllLabelsInteractor>();
        services.AddScoped<IUpdateLabelInputPort, UpdateLabelInteractor>();
        services.AddScoped<IDeleteLabelInputPort, DeleteLabelInteractor>();

        return services;
    }
}
