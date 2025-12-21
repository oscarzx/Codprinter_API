using Codprinter.Labels.Application.Interfaces.CreateLabel;
using Codprinter.Labels.Application.Interfaces.DeleteLabel;
using Codprinter.Labels.Application.Interfaces.GetAllLabels;
using Codprinter.Labels.Application.Interfaces.GetLabel;
using Codprinter.Labels.Application.Interfaces.Repositories;
using Codprinter.Labels.Application.Interfaces.UpdateLabel;
using Codprinter.Labels.InterfaceAdapters.Gateways.Repositories;
using Codprinter.Labels.InterfaceAdapters.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace Codprinter.Labels.InterfaceAdapters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddLabelPresenters(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ILabelRepository, LabelRepository>();
            services.AddScoped<ILabelTemplateRepository, LabelTemplateRepository>();

            // Presenters
            services.AddScoped<ICreateLabelOutputPort, CreateLabelPresenter>();
            services.AddScoped<IGetLabelOutputPort, GetLabelPresenter>();
            services.AddScoped<IGetAllLabelsOutputPort, GetAllLabelsPresenter>();
            services.AddScoped<IUpdateLabelOutputPort, UpdateLabelPresenter>();
            services.AddScoped<IDeleteLabelOutputPort, DeleteLabelPresenter>();
            return services;
        }
    }
}
