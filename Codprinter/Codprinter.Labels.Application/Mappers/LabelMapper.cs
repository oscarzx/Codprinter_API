using Codprinter.Labels.Application.POCOEntities;
using Codprinter.Labels.Domain;

namespace Codprinter.Labels.Application.Mappers;

public static class LabelMapper
{
    public static Label ToLabel(this LabelEntity labelEntity)
    {
        return new Label
        {
            Id = labelEntity.Id,
            LabelName = labelEntity.LabelName
        };
    }

    //public static LabelEntity ToEntity(this CreateLabelRequest request)
    //{
    //    return new LabelEntity
    //    {
    //        Id = Guid.NewGuid(),
    //        LabelName = request.LabelName
    //    };
    //}
}
