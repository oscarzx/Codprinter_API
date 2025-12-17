using Codprinter.Labels.Application.POCOEntities;

namespace Codprinter.Labels.Application.POCOAggregates
{
    // Transport object to persist the whole label template graph in one call
    public sealed class LabelTemplateAggregate
    {
        public LabelTemplate Template { get; init; } = null!;
        public List<LabelVariable> Variables { get; init; } = new();
        public List<DataBinding> DataBindings { get; init; } = new();
        public List<LabelElements> Elements { get; init; } = new();
        public List<Assets> Assets { get; init; } = new();
    }
}
