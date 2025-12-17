using Codprinter.Labels.Application.Dtos.CreateLabel;

namespace Codprinter.Labels.Application.Interfaces.CreateLabel;

public interface ICreateLabelInputPort
{
    Task Handle(CreateLabelRequest request);
}
