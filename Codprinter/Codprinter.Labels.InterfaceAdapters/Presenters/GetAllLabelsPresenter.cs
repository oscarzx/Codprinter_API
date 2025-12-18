using Codprinter.Labels.Application.Dtos.GetAllLabels;
using Codprinter.Labels.Application.Interfaces.GetAllLabels;

namespace Codprinter.Labels.InterfaceAdapters.Presenters;

internal sealed class GetAllLabelsPresenter : IGetAllLabelsOutputPort
{
    public GetAllLabelsResponse? Content { get; private set; }

    public void Handle(GetAllLabelsResponse response)
    {
        Content = response;
    }
}
