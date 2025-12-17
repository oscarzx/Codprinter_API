using Codprinter.Labels.Application.POCOAggregates;
using Codprinter.Labels.Application.POCOEntities;
using DomainEntity = Codprinter.Labels.Domain.LabelEntity;

namespace Codprinter.Labels.Application.Mappers
{
    public static class LabelPersistenceMapper
    {
        public static LabelTemplateAggregate ToPersistenceAggregate(this DomainEntity entity)
        {
            // Template
            var template = new LabelTemplate
            {
                Id = entity.Id,
                TemplateName = entity.Name,
                Description = entity.Description,
                Dpi = entity.Dpi,
                Units = entity.Units,
                Width = entity.WidthMm,
                Height = entity.HeightMm,
                RawJson = entity.RawJson,
                ElementsJson = entity.ElementsJson,
                IsActive = entity.IsActive,
                CreatedByUserId = entity.CreatedByUserId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Assets
            var assets = entity.Assets.Select(a => new Assets
            {
                Id = a.AssetId,
                Type = a.Type,
                Name = a.Name,
                MimeType = a.MimeType,
                StorageUrl = a.StorageUrl,
                BinaryData = a.BinaryData!,
                Checksum = a.Checksum ?? string.Empty,
                CreatedByUserId = a.CreatedByUserId,
                CreatedAt = DateTime.UtcNow
            }).ToList();

            // Variables
            var variables = entity.Variables.Select(v => new LabelVariable
            {
                Id = Guid.NewGuid(),
                LabelTemplateId = template.Id,
                Name = v.Name,
                DisplayName = v.DisplayName,
                DataType = v.DataType,
                SourceType = v.SourceType,
                DefaultValue = v.DefaultValue,
                IsRequired = v.IsRequired,
                ValidationRuleJson = v.ValidationRuleJson,
                CalculationExpr = v.CalculationExpr,
                CreatedAt = DateTime.UtcNow
            }).ToList();

            // DataBindings: only for variables with database source
            var variableIndex = variables.ToDictionary(v => v.Name, v => v.Id);
            var bindings = entity.Variables
            .Where(v => v.SourceType == "database" && v.DataBinding != null)
            .Select(v => new DataBinding
            {
                Id = Guid.NewGuid(),
                LabelVariableId = variableIndex[v.Name],
                ConnectionName = v.DataBinding!.ConnectionName,
                QueryType = v.DataBinding!.QueryType,
                TableName = v.DataBinding!.TableName,
                ColumnName = v.DataBinding!.ColumnName,
                SqlQuery = v.DataBinding!.SqlQuery,
                KeyMappingJson = v.DataBinding!.KeyMappingJson ?? string.Empty,
                CacheTtlSeconds = v.DataBinding!.CacheTtlSeconds
            }).ToList();

            // Elements
            // resolve variable name to id when provided
            var elements = entity.Elements.Select(e => new LabelElements
            {
                Id = Guid.NewGuid(),
                LabelTemplateId = template.Id,
                Type = e.Type,
                Xmm = (float)e.Xmm,
                Ymm = (float)e.Ymm,
                WidthMm = e.WidthMm.HasValue ? (float?)e.WidthMm.Value : null,
                HeightMm = e.HeightMm.HasValue ? (float?)e.HeightMm.Value : null,
                RotationDeg = (float)e.RotationDeg,
                ZIndex = e.ZIndex,
                PropsJson = e.PropsJson,
                LabelVariableId = e.LabelVariableName != null && variableIndex.TryGetValue(e.LabelVariableName, out var vid) ? vid : null,
                AssetId = e.AssetId
            }).ToList();

            return new LabelTemplateAggregate
            {
                Template = template,
                Variables = variables,
                DataBindings = bindings,
                Elements = elements,
                Assets = assets
            };
        }
    }
}
