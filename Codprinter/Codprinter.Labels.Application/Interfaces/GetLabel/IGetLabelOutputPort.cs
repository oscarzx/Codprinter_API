using Codprinter.Labels.Application.Dtos.GetLabel;

namespace Codprinter.Labels.Application.Interfaces.GetLabel;

public interface IGetLabelOutputPort
{
    void Handle(GetLabelResponse response);
}
