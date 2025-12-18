using Codprinter.Labels.Application.Dtos.GetAllLabels;

namespace Codprinter.Labels.Application.Interfaces.GetAllLabels;

public interface IGetAllLabelsInputPort
{
    Task Handle(GetAllLabelsRequest request);
}
