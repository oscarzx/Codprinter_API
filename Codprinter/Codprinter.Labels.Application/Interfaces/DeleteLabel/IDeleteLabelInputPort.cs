using Codprinter.Labels.Application.Dtos.DeleteLabel;

namespace Codprinter.Labels.Application.Interfaces.DeleteLabel;

public interface IDeleteLabelInputPort
{
    Task Handle(DeleteLabelRequest request);
}
