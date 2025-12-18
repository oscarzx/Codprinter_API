using Codprinter.Labels.Application.Dtos.GetLabel;
using Codprinter.Labels.Application.Interfaces.GetLabel;

namespace Codprinter.Labels.InterfaceAdapters.Presenters;

internal sealed class GetLabelPresenter : IGetLabelOutputPort
{
    public GetLabelResponse? Content { get; private set; }

    public void Handle(GetLabelResponse response)
    {
        Content = response;
    }
}
