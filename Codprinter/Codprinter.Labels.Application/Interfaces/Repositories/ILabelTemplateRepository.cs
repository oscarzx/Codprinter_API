using Codprinter.Labels.Application.POCOAggregates;
using Codprinter.Shared.Application.UnitOfWork;

namespace Codprinter.Labels.Application.Interfaces.Repositories
{
    public interface ILabelTemplateRepository : IUnitOfWork
    {
        Task AddAsync(LabelTemplateAggregate aggregate);
    }
}
