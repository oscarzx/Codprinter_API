using Codprinter.Labels.Application.POCOEntities;
using Codprinter.Labels.DataContexts.EFCore.DataContexts;
using Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces;
using Codprinter.Shared.Infrastructure.Options;
using Microsoft.Extensions.Options;

namespace Codprinter.Labels.DataContexts.EFCore.Services
{
    internal sealed class LabelTemplateCommandsDataContext(IOptions<DBOptions> options)
    : CodprinterLabelsContext(options), ILabelTemplateCommandsDataContext
    {
        public async Task AddTemplateAsync(LabelTemplate template) => await AddAsync(template);
        public async Task AddVariablesAsync(IEnumerable<LabelVariable> variables) => await AddRangeAsync(variables);
        public async Task AddDataBindingsAsync(IEnumerable<DataBinding> dataBindings) => await AddRangeAsync(dataBindings);
        public async Task AddElementsAsync(IEnumerable<LabelElements> elements) => await AddRangeAsync(elements);
        public async Task AddAssetsAsync(IEnumerable<Assets> assets) => await AddRangeAsync(assets);
        public async Task SaveChangesAsync() => await base.SaveChangesAsync();
    }
}
