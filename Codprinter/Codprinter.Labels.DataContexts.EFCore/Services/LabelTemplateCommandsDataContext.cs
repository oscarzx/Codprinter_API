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
        // Commands (create)
        public async Task AddTemplateAsync(LabelTemplate template) => await AddAsync(template);
        public async Task AddVariablesAsync(IEnumerable<LabelVariable> variables) => await AddRangeAsync(variables);
        public async Task AddDataBindingsAsync(IEnumerable<DataBinding> dataBindings) => await AddRangeAsync(dataBindings);
        public async Task AddElementsAsync(IEnumerable<LabelElements> elements) => await AddRangeAsync(elements);
        public async Task AddAssetsAsync(IEnumerable<Assets> assets) => await AddRangeAsync(assets);

        // Commands (update)
        public async Task UpdateTemplateAsync(LabelTemplate template)
        {
            Update(template);
            await Task.CompletedTask;
        }

        public async Task UpdateVariablesAsync(IEnumerable<LabelVariable> variables)
        {
            UpdateRange(variables);
            await Task.CompletedTask;
        }

        public async Task UpdateDataBindingsAsync(IEnumerable<DataBinding> dataBindings)
        {
            UpdateRange(dataBindings);
            await Task.CompletedTask;
        }

        public async Task UpdateElementsAsync(IEnumerable<LabelElements> elements)
        {
            UpdateRange(elements);
            await Task.CompletedTask;
        }

        public async Task UpdateAssetsAsync(IEnumerable<Assets> assets)
        {
            UpdateRange(assets);
            await Task.CompletedTask;
        }

        public async Task DeleteTemplateByNameAsync(string templateName)
        {
            // Localizar la plantilla por nombre
            var template = await LabelTemplates.FirstOrDefaultAsync(t => t.TemplateName == templateName);
            if (template is null)
            {
                return;
            }

            // Cargar entidades relacionadas
            var templateId = template.Id;

            var variables = await LabelVariables
                .Where(v => v.LabelTemplateId == templateId)
                .ToListAsync();
            var variableIds = variables.Select(v => v.Id).ToList();

            var bindings = variableIds.Count > 0
                ? await DataBindings.Where(b => variableIds.Contains(b.LabelVariableId)).ToListAsync()
                : new List<DataBinding>();

            var elements = await LabelElements
                .Where(e => e.LabelTemplateId == templateId)
                .ToListAsync();

            // Opcional: si quieres borrar también assets solo cuando no estén referenciados por otras plantillas,
            // aquí tendrías que verificar referencias cruzadas. Por ahora asumimos assets dedicados a esta plantilla.
            var assetIds = elements
                .Where(e => e.AssetId.HasValue)
                .Select(e => e.AssetId!.Value)
                .Distinct()
                .ToList();
            var assets = assetIds.Count > 0
                ? await Assets.Where(a => assetIds.Contains(a.Id)).ToListAsync()
                : new List<Assets>();

            // Eliminar en orden seguro por dependencias
            if (bindings.Count > 0)
            {
                DataBindings.RemoveRange(bindings);
            }

            if (variables.Count > 0)
            {
                LabelVariables.RemoveRange(variables);
            }

            if (elements.Count > 0)
            {
                LabelElements.RemoveRange(elements);
            }

            if (assets.Count > 0)
            {
                Assets.RemoveRange(assets);
            }

            LabelTemplates.Remove(template);
        }

        public async Task SaveChangesAsync() => await base.SaveChangesAsync();

        // Queries
        public async Task<LabelTemplate?> GetTemplateByNameAsync(string templateName)
            => await LabelTemplates.AsNoTracking().FirstOrDefaultAsync(t => t.TemplateName == templateName);

        public async Task<List<LabelTemplate>> GetAllTemplatesAsync(bool onlyActive)
        {
            var query = LabelTemplates.AsNoTracking().AsQueryable();
            if (onlyActive)
            {
                query = query.Where(t => t.IsActive);
            }
            return await query.ToListAsync();
        }

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
