using Codprinter.Labels.Application.POCOEntities;

namespace Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces
{
    // Contract specialized to persist and query the full label template graph
    public interface ILabelTemplateCommandsDataContext
    {
        // Commands (create)
        Task AddTemplateAsync(LabelTemplate template);
        Task AddVariablesAsync(IEnumerable<LabelVariable> variables);
        Task AddDataBindingsAsync(IEnumerable<DataBinding> dataBindings);
        Task AddElementsAsync(IEnumerable<LabelElements> elements);
        Task AddAssetsAsync(IEnumerable<Assets> assets);

        // Commands (update)
        /// <summary>
        /// Updates an existing label template and its related entities (variables, elements, assets).
        /// Implementations should track entities by their Id and apply changes instead of inserting new rows.
        /// A simple strategy can be: load current graph, replace properties/collections, then SaveChanges.
        /// </summary>
        Task UpdateTemplateAsync(LabelTemplate template);
        Task UpdateVariablesAsync(IEnumerable<LabelVariable> variables);
        Task UpdateDataBindingsAsync(IEnumerable<DataBinding> dataBindings);
        Task UpdateElementsAsync(IEnumerable<LabelElements> elements);
        Task UpdateAssetsAsync(IEnumerable<Assets> assets);

        /// <summary>
        /// Permanently deletes a label template and all related entities (variables, data bindings,
        /// elements, assets) identified by its name.
        /// </summary>
        Task DeleteTemplateByNameAsync(string templateName);

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
