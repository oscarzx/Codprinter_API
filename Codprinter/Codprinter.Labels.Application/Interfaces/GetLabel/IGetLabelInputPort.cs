using Codprinter.Labels.Application.Dtos.GetLabel;

namespace Codprinter.Labels.Application.Interfaces.GetLabel;

public interface IGetLabelInputPort
{
    Task Handle(GetLabelRequest request);
}
