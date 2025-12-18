using Codprinter.Labels.Application.Dtos.GetAllLabels;

namespace Codprinter.Labels.Application.Interfaces.GetAllLabels;

public interface IGetAllLabelsOutputPort
{
    void Handle(GetAllLabelsResponse response);
}
