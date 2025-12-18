using Codprinter.Labels.Application.POCOEntities;

namespace Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces
{
    // Contract specialized to persist and query the full label template graph
    public interface ILabelTemplateCommandsDataContext
    {
        // Commands
        Task AddTemplateAsync(LabelTemplate template);
        Task AddVariablesAsync(IEnumerable<LabelVariable> variables);
        Task AddDataBindingsAsync(IEnumerable<DataBinding> dataBindings);
        Task AddElementsAsync(IEnumerable<LabelElements> elements);
        Task AddAssetsAsync(IEnumerable<Assets> assets);
        Task SaveChangesAsync();

        // Queries
        Task<LabelTemplate?> GetTemplateByNameAsync(string templateName);
        Task<List<LabelTemplate>> GetAllTemplatesAsync(bool onlyActive);
        Task<List<LabelVariable>> GetVariablesByTemplateIdAsync(Guid templateId);
        Task<List<DataBinding>> GetBindingsByVariableIdsAsync(IEnumerable<Guid> variableIds);
        Task<List<LabelElements>> GetElementsByTemplateIdAsync(Guid templateId);
        Task<List<Assets>> GetAssetsByIdsAsync(IEnumerable<Guid> assetIds);
    }
}
