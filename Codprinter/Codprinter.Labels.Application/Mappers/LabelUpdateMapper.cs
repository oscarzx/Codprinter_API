using Codprinter.Labels.Application.Dtos.UpdateLabel;
using Codprinter.Labels.Domain;
using DomainAsset = Codprinter.Labels.Domain.AssetRef;
using DomainBinding = Codprinter.Labels.Domain.DataBinding;
using DomainElement = Codprinter.Labels.Domain.LabelElement;
using DomainVariable = Codprinter.Labels.Domain.LabelVariable;

namespace Codprinter.Labels.Application.Mappers;

public static class LabelUpdateMapper
{
    public static UpdateLabelTemplateData ToUpdateTemplateData(this UpdateLabelRequest request)
    {
        return new UpdateLabelTemplateData
        {
            Name = string.IsNullOrWhiteSpace(request.Name) ? request.LabelName : request.Name,
            Description = request.Description,
            Dpi = request.Dpi,
            Units = request.Units,
            WidthMm = request.WidthMm,
            HeightMm = request.HeightMm,
            RawJson = request.RawJson,
            ElementsJson = request.ElementsJson,
            IsActive = request.IsActive,
            CreatedByUserId = request.CreatedByUserId
        };
    }

    public static (IEnumerable<DomainVariable> variables,
    IEnumerable<DomainElement> elements,
    IEnumerable<DomainAsset> assets) ToDomainCollections(this UpdateLabelRequest request)
    {
        var variables = request.Variables?.Select(v => new DomainVariable
        {
            Id = v.Id,
            Name = v.Name,
            DisplayName = v.DisplayName,
            DataType = v.DataType,
            SourceType = v.SourceType,
            DefaultValue = v.DefaultValue,
            IsRequired = v.IsRequired,
            ValidationRuleJson = v.ValidationRuleJson,
            CalculationExpr = v.CalculationExpr,
            DataBinding = v.DataBinding == null ? null : new DomainBinding
            {
                Id = v.DataBinding.Id,
                LabelVariableId = v.Id,
                ConnectionName = v.DataBinding.ConnectionName,
                QueryType = v.DataBinding.QueryType,
                TableName = v.DataBinding.TableName,
                ColumnName = v.DataBinding.ColumnName,
                SqlQuery = v.DataBinding.SqlQuery,
                KeyMappingJson = v.DataBinding.KeyMappingJson,
                CacheTtlSeconds = v.DataBinding.CacheTtlSeconds
            }
        }).ToList() ?? new List<DomainVariable>();

        var assets = request.Assets?.Select(a => new DomainAsset
        {
            AssetId = a.Id,
            Type = a.Type,
            Name = a.Name,
            MimeType = a.MimeType,
            StorageUrl = a.StorageUrl,
            BinaryData = a.BinaryData,
            Checksum = a.Checksum,
            CreatedByUserId = a.CreatedByUserId
        }).ToList() ?? new List<DomainAsset>();

        var elements = request.Elements?.Select(e => new DomainElement
        {
            Id = e.Id,
            Type = e.Type,
            Xmm = e.Xmm,
            Ymm = e.Ymm,
            WidthMm = e.WidthMm,
            HeightMm = e.HeightMm,
            RotationDeg = e.RotationDeg,
            ZIndex = e.ZIndex,
            PropsJson = e.PropsJson,
            LabelVariableName = e.LabelVariableName,
            AssetId = e.AssetId
        }).ToList() ?? new List<DomainElement>();

        return (variables, elements, assets);
    }
}
