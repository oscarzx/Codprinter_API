namespace Codprinter.Shared.Application.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChanges();
}
