using Codprinter.Labels.Application.Dtos.UpdateLabel;
using Codprinter.Labels.Application.Interfaces.UpdateLabel;

namespace Codprinter.Labels.InterfaceAdapters.Presenters;

internal sealed class UpdateLabelPresenter : IUpdateLabelOutputPort
{
    public UpdateLabelResponse? Content { get; private set; }

    public void Handle(UpdateLabelResponse response)
    {
        Content = response;
    }
}
