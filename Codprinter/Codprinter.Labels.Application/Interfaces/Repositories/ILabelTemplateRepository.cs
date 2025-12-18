using Codprinter.Labels.Application.POCOAggregates;
using Codprinter.Shared.Application.UnitOfWork;
using Codprinter.Labels.Domain;

namespace Codprinter.Labels.Application.Interfaces.Repositories
{
    public interface ILabelTemplateRepository : IUnitOfWork
    {
        Task AddAsync(LabelTemplateAggregate aggregate);

        Task<LabelEntity?> GetByTemplateNameAsync(string templateName);
    }
}
