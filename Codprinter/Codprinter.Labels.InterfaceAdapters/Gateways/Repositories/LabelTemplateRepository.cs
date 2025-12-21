using Codprinter.Labels.Application.Interfaces.Repositories;
using Codprinter.Labels.Application.POCOAggregates;
using Codprinter.Labels.Application.POCOEntities;
using Codprinter.Labels.Domain;
using Codprinter.Labels.InterfaceAdapters.Gateways.Interfaces;
using DomainBinding = Codprinter.Labels.Domain.DataBinding;
using PocoBinding = Codprinter.Labels.Application.POCOEntities.DataBinding;

namespace Codprinter.Labels.InterfaceAdapters.Gateways.Repositories
{
    internal sealed class LabelTemplateRepository(
        ILabelTemplateCommandsDataContext dataContext)
        : ILabelTemplateRepository
    {
        public async Task AddAsync(LabelTemplateAggregate aggregate)
        {
            await dataContext.AddTemplateAsync(aggregate.Template);
            if (aggregate.Assets.Count > 0)
            {
                await dataContext.AddAssetsAsync(aggregate.Assets);
            }
            if (aggregate.Variables.Count > 0)
            {
                await dataContext.AddVariablesAsync(aggregate.Variables);
            }
            if (aggregate.DataBindings.Count > 0)
            {
                await dataContext.AddDataBindingsAsync(aggregate.DataBindings);
            }
            if (aggregate.Elements.Count > 0)
            {
                await dataContext.AddElementsAsync(aggregate.Elements);
            }
        }

        public async Task UpdateAsync(LabelTemplateAggregate aggregate)
        {
            // Use explicit update operations so EF can track existing entities by Id
            await dataContext.UpdateTemplateAsync(aggregate.Template);
            if (aggregate.Assets.Count > 0)
            {
                await dataContext.UpdateAssetsAsync(aggregate.Assets);
            }
            if (aggregate.Variables.Count > 0)
            {
                await dataContext.UpdateVariablesAsync(aggregate.Variables);
            }
            if (aggregate.DataBindings.Count > 0)
            {
                await dataContext.UpdateDataBindingsAsync(aggregate.DataBindings);
            }
            if (aggregate.Elements.Count > 0)
            {
                await dataContext.UpdateElementsAsync(aggregate.Elements);
            }
        }

        public async Task<LabelEntity?> GetByTemplateNameAsync(string templateName)
        {
            var template = await dataContext.GetTemplateByNameAsync(templateName);
            if (template is null)
            {
                return null;
            }

            var variables = await dataContext.GetVariablesByTemplateIdAsync(template.Id);
            var variableIds = variables.Select(v => v.Id).ToList();
            var bindings = variableIds.Count > 0
                ? await dataContext.GetBindingsByVariableIdsAsync(variableIds)
                : new List<PocoBinding>();

            var elements = await dataContext.GetElementsByTemplateIdAsync(template.Id);

            // Collect asset ids from elements
            var assetIds = elements.Where(e => e.AssetId.HasValue)
                .Select(e => e.AssetId!.Value)
                .Distinct()
                .ToList();
            var assets = assetIds.Count > 0
                ? await dataContext.GetAssetsByIdsAsync(assetIds)
                : new List<Assets>();

            // Map POCOs to domain objects
            var domainVariables = variables.Select(v => new Domain.LabelVariable
            {
                Id = v.Id,
                LabelTemplateId = v.LabelTemplateId,
                Name = v.Name,
                DisplayName = v.DisplayName,
                DataType = v.DataType,
                SourceType = v.SourceType,
                DefaultValue = v.DefaultValue,
                IsRequired = v.IsRequired,
                ValidationRuleJson = v.ValidationRuleJson,
                CalculationExpr = v.CalculationExpr
            }).ToList();

            var domainBindings = bindings.Select(b => new DomainBinding
            {
                Id = b.Id,
                LabelVariableId = b.LabelVariableId,
                ConnectionName = b.ConnectionName,
                QueryType = b.QueryType,
                TableName = b.TableName,
                ColumnName = b.ColumnName,
                SqlQuery = b.SqlQuery,
                KeyMappingJson = b.KeyMappingJson,
                CacheTtlSeconds = b.CacheTtlSeconds
            }).ToList();

            var domainElements = elements.Select(e => new Domain.LabelElement
            {
                Id = e.Id,
                LabelTemplateId = e.LabelTemplateId,
                Type = e.Type,
                Xmm = (decimal)e.Xmm,
                Ymm = (decimal)e.Ymm,
                WidthMm = e.WidthMm.HasValue ? (decimal?)e.WidthMm.Value : null,
                HeightMm = e.HeightMm.HasValue ? (decimal?)e.HeightMm.Value : null,
                RotationDeg = (decimal)e.RotationDeg,
                ZIndex = e.ZIndex,
                PropsJson = e.PropsJson,
                // For now we only fill LabelVariableName when we can resolve it
                LabelVariableName = variables.FirstOrDefault(v => v.Id == e.LabelVariableId)?.Name,
                AssetId = e.AssetId
            }).ToList();

            var domainAssets = assets.Select(a => new Domain.AssetRef
            {
                AssetId = a.Id,
                Type = a.Type,
                Name = a.Name,
                MimeType = a.MimeType,
                StorageUrl = a.StorageUrl,
                BinaryData = a.BinaryData,
                Checksum = a.Checksum,
                CreatedByUserId = a.CreatedByUserId
            }).ToList();

            var entity = LabelEntity.FromPersistence(
                template.Id,
                template.TemplateName,
                template.Description,
                template.Dpi,
                template.Units,
                template.Width,
                template.Height,
                template.RawJson,
                template.ElementsJson,
                template.IsActive,
                template.CreatedByUserId,
                domainVariables,
                domainBindings,
                domainElements,
                domainAssets);

            return entity;
        }

        public async Task<IReadOnlyList<LabelTemplateSummary>> GetAllSummariesAsync(bool onlyActive)
        {
            var templates = await dataContext.GetAllTemplatesAsync(onlyActive);
            return templates
                .Select(t => new LabelTemplateSummary(
                    t.Id,
                    t.TemplateName,
                    t.Description,
                    t.Dpi,
                    t.Units,
                    t.Width,
                    t.Height,
                    t.IsActive))
                .ToList();
        }

        public async Task DeleteByNameAsync(string templateName)
        {
            await dataContext.DeleteTemplateByNameAsync(templateName);
        }

        public async Task SaveChanges() => await dataContext.SaveChangesAsync();
    }
}
