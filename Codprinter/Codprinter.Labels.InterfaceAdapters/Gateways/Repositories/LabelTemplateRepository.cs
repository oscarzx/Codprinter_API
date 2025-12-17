using Codprinter.Labels.Application.Interfaces.Repositories;
using Codprinter.Labels.Application.POCOAggregates;
using Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces;

namespace Codprinter.Labels.InterfaceAdapters.Gateways.Repositories
{
    internal sealed class LabelTemplateRepository(ILabelTemplateCommandsDataContext dataContext)
    : ILabelTemplateRepository
    {
        public async Task AddAsync(LabelTemplateAggregate aggregate)
        {
            await dataContext.AddTemplateAsync(aggregate.Template);
            if (aggregate.Assets.Count > 0)
            {
                await dataContext.AddAssetsAsync(aggregate.Assets);
            }
            if (aggregate.Variables.Count > 0)
            {
                await dataContext.AddVariablesAsync(aggregate.Variables);
            }
            if (aggregate.DataBindings.Count > 0)
            {
                await dataContext.AddDataBindingsAsync(aggregate.DataBindings);
            }
            if (aggregate.Elements.Count > 0)
            {
                await dataContext.AddElementsAsync(aggregate.Elements);
            }
        }

        public async Task SaveChanges() => await dataContext.SaveChangesAsync();
    }
}
