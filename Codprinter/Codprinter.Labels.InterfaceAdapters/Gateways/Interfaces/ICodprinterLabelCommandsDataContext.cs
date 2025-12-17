using Codprinter.Labels.Application.POCOEntities;

namespace Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces;

public interface ICodprinterLabelCommandsDataContext
{
    Task AddLabelAsync(Label label);
    Task SaveChangesAsync();
}
