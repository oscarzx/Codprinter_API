using Codprinter.Labels.Application.POCOEntities;
using Codprinter.Labels.DataContexts.EFCore.DataContexts;
using Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces;
using Codprinter.Shared.Infrastructure.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Codprinter.Labels.DataContexts.EFCore.Services
{
    internal sealed class LabelTemplateCommandsDataContext(IOptions<DBOptions> options)
    : CodprinterLabelsContext(options), ILabelTemplateCommandsDataContext
    {
        // Commands
        public async Task AddTemplateAsync(LabelTemplate template) => await AddAsync(template);
        public async Task AddVariablesAsync(IEnumerable<LabelVariable> variables) => await AddRangeAsync(variables);
        public async Task AddDataBindingsAsync(IEnumerable<DataBinding> dataBindings) => await AddRangeAsync(dataBindings);
        public async Task AddElementsAsync(IEnumerable<LabelElements> elements) => await AddRangeAsync(elements);
        public async Task AddAssetsAsync(IEnumerable<Assets> assets) => await AddRangeAsync(assets);
        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        // Queries
        public async Task<LabelTemplate?> GetTemplateByNameAsync(string templateName)
        => await LabelTemplates.AsNoTracking().FirstOrDefaultAsync(t => t.TemplateName == templateName);

        public async Task<List<LabelVariable>> GetVariablesByTemplateIdAsync(Guid templateId)
        => await LabelVariables.AsNoTracking().Where(v => v.LabelTemplateId == templateId).ToListAsync();

        public async Task<List<DataBinding>> GetBindingsByVariableIdsAsync(IEnumerable<Guid> variableIds)
        => await DataBindings.AsNoTracking()
 .Where(b => variableIds.Contains(b.LabelVariableId))
 .ToListAsync();

        public async Task<List<LabelElements>> GetElementsByTemplateIdAsync(Guid templateId)
        => await LabelElements.AsNoTracking().Where(e => e.LabelTemplateId == templateId).ToListAsync();

        public async Task<List<Assets>> GetAssetsByIdsAsync(IEnumerable<Guid> assetIds)
        => await Assets.AsNoTracking().Where(a => assetIds.Contains(a.Id)).ToListAsync();
    }
}
