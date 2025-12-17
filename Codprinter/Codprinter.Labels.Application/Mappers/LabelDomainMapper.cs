using Codprinter.Labels.Application.Dtos.CreateLabel;
using DomainAsset = Codprinter.Labels.Domain.AssetRef;
using DomainBinding = Codprinter.Labels.Domain.DataBinding;
using DomainElement = Codprinter.Labels.Domain.LabelElement;
using DomainEntity = Codprinter.Labels.Domain.LabelEntity;
using DomainVariable = Codprinter.Labels.Domain.LabelVariable;

namespace Codprinter.Labels.Application.Mappers
{
    public static class LabelDomainMapper
    {
        // Build the domain aggregate from the incoming request and run domain validations via factory
        public static DomainEntity ToDomainEntity(this CreateLabelRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            var variables = request.Variables?.Select(v => new DomainVariable
            {
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
                    ConnectionName = v.DataBinding.ConnectionName,
                    QueryType = v.DataBinding.QueryType,
                    TableName = v.DataBinding.TableName,
                    ColumnName = v.DataBinding.ColumnName,
                    SqlQuery = v.DataBinding.SqlQuery,
                    KeyMappingJson = v.DataBinding.KeyMappingJson,
                    CacheTtlSeconds = v.DataBinding.CacheTtlSeconds
                }
            }).ToList();

            var assets = request.Assets?.Select(a => new DomainAsset
            {
                AssetId = Guid.Empty, // let domain assign a new one if empty
                Type = a.Type,
                Name = a.Name,
                MimeType = a.MimeType,
                StorageUrl = a.StorageUrl,
                BinaryData = a.BinaryData,
                Checksum = a.Checksum,
                CreatedByUserId = a.CreatedByUserId
            }).ToList();

            var elements = request.Elements?.Select(e => new DomainElement
            {
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
            }).ToList();

            var entity = DomainEntity.Create(
            id: Guid.Empty,
            name: string.IsNullOrWhiteSpace(request.Name) ? request.LabelName : request.Name,
            description: request.Description,
            dpi: request.Dpi,
            units: request.Units,
            widthMm: request.WidthMm,
            heightMm: request.HeightMm,
            rawJson: request.RawJson,
            elementsJson: request.ElementsJson,
            isActive: request.IsActive,
            createdByUserId: request.CreatedByUserId,
            variables: variables,
            elements: elements,
            assets: assets);

            return entity;
        }
    }
}
