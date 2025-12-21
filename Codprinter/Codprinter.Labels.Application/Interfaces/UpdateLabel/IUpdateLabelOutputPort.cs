using Codprinter.Labels.Application.Dtos.UpdateLabel;

namespace Codprinter.Labels.Application.Interfaces.UpdateLabel;

public interface IUpdateLabelOutputPort
{
    void Handle(UpdateLabelResponse response);
}
