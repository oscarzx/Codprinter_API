using Codprinter.Labels.Application.POCOEntities;
using Codprinter.Shared.Application.UnitOfWork;

namespace Codprinter.Labels.Application.Interfaces.Repositories;

public interface ILabelRepository : IUnitOfWork
{
    Task AddAsync(Label label);
}
