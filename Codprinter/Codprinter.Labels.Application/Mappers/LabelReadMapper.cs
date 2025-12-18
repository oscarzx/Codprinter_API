using Codprinter.Labels.Application.Dtos.GetLabel;
using Codprinter.Labels.Domain;

namespace Codprinter.Labels.Application.Mappers;

public static class LabelReadMapper
{
    public static GetLabelResponse ToGetLabelResponse(this LabelEntity entity)
    {
        var response = new GetLabelResponse
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Dpi = entity.Dpi,
            Units = entity.Units,
            WidthMm = entity.WidthMm,
            HeightMm = entity.HeightMm,
            RawJson = entity.RawJson,
            ElementsJson = entity.ElementsJson,
            IsActive = entity.IsActive,
            CreatedByUserId = entity.CreatedByUserId
        };

        // Variables with optional databinding
        foreach (var v in entity.Variables)
        {
            var variableDto = new GetLabelVariableDto
            {
                Id = v.Id,
                Name = v.Name,
                DisplayName = v.DisplayName,
                DataType = v.DataType,
                SourceType = v.SourceType,
                DefaultValue = v.DefaultValue,
                IsRequired = v.IsRequired,
                ValidationRuleJson = v.ValidationRuleJson,
                CalculationExpr = v.CalculationExpr
            };

            if (v.DataBinding != null)
            {
                variableDto.DataBinding = new GetDataBindingDto
                {
                    Id = v.DataBinding.Id,
                    ConnectionName = v.DataBinding.ConnectionName,
                    QueryType = v.DataBinding.QueryType,
                    TableName = v.DataBinding.TableName,
                    ColumnName = v.DataBinding.ColumnName,
                    SqlQuery = v.DataBinding.SqlQuery,
                    KeyMappingJson = v.DataBinding.KeyMappingJson,
                    CacheTtlSeconds = v.DataBinding.CacheTtlSeconds
                };
            }

            response.Variables.Add(variableDto);
        }

        // Elements
        foreach (var e in entity.Elements)
        {
            var elementDto = new GetLabelElementDto
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
                // For the frontend we expose direct ids for linkage
                LabelVariableId = null, // can be resolved in repo if needed
                AssetId = e.AssetId
            };

            response.Elements.Add(elementDto);
        }

        // Assets
        foreach (var a in entity.Assets)
        {
            var assetDto = new GetAssetDto
            {
                Id = a.AssetId,
                Type = a.Type,
                Name = a.Name,
                MimeType = a.MimeType,
                StorageUrl = a.StorageUrl,
                BinaryData = a.BinaryData ?? Array.Empty<byte>(),
                Checksum = a.Checksum
            };

            response.Assets.Add(assetDto);
        }

        return response;
    }
}
