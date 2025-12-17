using Codprinter.Labels.Application.POCOEntities;

namespace Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces
{
    // Commands contract specialized to persist the full label template graph
    public interface ILabelTemplateCommandsDataContext
    {
        Task AddTemplateAsync(LabelTemplate template);
        Task AddVariablesAsync(IEnumerable<LabelVariable> variables);
        Task AddDataBindingsAsync(IEnumerable<DataBinding> dataBindings);
        Task AddElementsAsync(IEnumerable<LabelElements> elements);
        Task AddAssetsAsync(IEnumerable<Assets> assets);
        Task SaveChangesAsync();
    }
}
