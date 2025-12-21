using Codprinter.Labels.Application.Dtos.UpdateLabel;

namespace Codprinter.Labels.Application.Interfaces.UpdateLabel;

public interface IUpdateLabelInputPort
{
    Task Handle(UpdateLabelRequest request);
}
