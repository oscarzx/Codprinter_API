using Codprinter.Labels.Application.POCOAggregates;
using Codprinter.Labels.Domain;
using Codprinter.Shared.Application.UnitOfWork;

namespace Codprinter.Labels.Application.Interfaces.Repositories
{
    public interface ILabelTemplateRepository : IUnitOfWork
    {
        Task AddAsync(LabelTemplateAggregate aggregate);

        Task<LabelEntity?> GetByTemplateNameAsync(string templateName);

        Task<IReadOnlyList<LabelTemplateSummary>> GetAllSummariesAsync(bool onlyActive);
    }
}
