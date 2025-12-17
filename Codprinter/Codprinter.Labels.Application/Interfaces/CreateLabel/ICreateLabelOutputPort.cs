using Codprinter.Labels.Application.Dtos.CreateLabel;

namespace Codprinter.Labels.Application.Interfaces.CreateLabel;

public interface ICreateLabelOutputPort
{
    CreateLabelResponse Content { get; }
    Task Handle(CreateLabelResponse response);
}
