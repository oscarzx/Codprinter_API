using Codprinter.Labels.Application.Dtos.DeleteLabel;

namespace Codprinter.Labels.Application.Interfaces.DeleteLabel;

public interface IDeleteLabelOutputPort
{
    DeleteLabelResponse Content { get; }
    Task Handle(DeleteLabelResponse response);
}
