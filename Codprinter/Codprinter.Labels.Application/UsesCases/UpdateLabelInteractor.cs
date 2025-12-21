using Codprinter.Labels.Application.Dtos.CreateLabel;
using Codprinter.Labels.Application.Dtos.UpdateLabel;
using Codprinter.Labels.Application.Interfaces.CreateLabel;
using Codprinter.Labels.Application.Interfaces.DeleteLabel;
using Codprinter.Labels.Application.Interfaces.Repositories;
using Codprinter.Labels.Application.Interfaces.UpdateLabel;
using Codprinter.Labels.Domain.Exceptions;

namespace Codprinter.Labels.Application.UsesCases;

internal sealed class UpdateLabelInteractor(
 ILabelTemplateRepository repository,
 IDeleteLabelInputPort deleteLabelInputPort,
 ICreateLabelInputPort createLabelInputPort,
 IUpdateLabelOutputPort outputPort) : IUpdateLabelInputPort
{
    public async Task Handle(UpdateLabelRequest request)
    {
        // Para update, exigimos al menos un nombre (Name o LabelName)
        if (string.IsNullOrWhiteSpace(request.Name) && string.IsNullOrWhiteSpace(request.LabelName))
        {
            throw new InvalidLabelException("label.name.required", "Template name is required to update a label");
        }

        // Normalizar nombre igual que en create
        var name = string.IsNullOrWhiteSpace(request.Name) ? request.LabelName : request.Name;
        name = name?.Trim() ?? string.Empty;

        // Validar que exista el label antes de intentar borrarlo
        var existing = await repository.GetByTemplateNameAsync(name);
        if (existing is null)
        {
            throw new InvalidLabelException("label.not_found", $"Label template '{name}' was not found");
        }

        //1) Borrar el label actual usando el caso de uso DeleteLabel
        var deleteRequest = new Dtos.DeleteLabel.DeleteLabelRequest
        {
            TemplateName = name
        };
        await deleteLabelInputPort.Handle(deleteRequest);

        //2) Mapear los DTOs de update a DTOs de create
        var variableRequests = request.Variables.Select(v => new LabelVariableRequest
        {
            Name = v.Name,
            DisplayName = v.DisplayName,
            DataType = v.DataType,
            SourceType = v.SourceType,
            DefaultValue = v.DefaultValue,
            IsRequired = v.IsRequired,
            ValidationRuleJson = v.ValidationRuleJson,
            CalculationExpr = v.CalculationExpr,
            DataBinding = v.DataBinding == null ? null : new DataBindingRequest
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

        var elementRequests = request.Elements.Select(e => new LabelElementRequest
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

        var assetRequests = request.Assets.Select(a => new AssetRequest
        {
            Type = a.Type,
            Name = a.Name,
            MimeType = a.MimeType,
            StorageUrl = a.StorageUrl,
            BinaryData = a.BinaryData,
            Checksum = a.Checksum,
            CreatedByUserId = a.CreatedByUserId
        }).ToList();

        //3) Crear un nuevo label con el mismo nombre usando el caso de uso CreateLabel
        var createRequest = new CreateLabelRequest
        {
            // Mantener compatibilidad con LabelName
            LabelName = request.LabelName,
            Name = name,
            Description = request.Description,
            Dpi = request.Dpi,
            Units = request.Units,
            WidthMm = request.WidthMm,
            HeightMm = request.HeightMm,
            RawJson = request.RawJson,
            ElementsJson = request.ElementsJson,
            IsActive = request.IsActive,
            CreatedByUserId = request.CreatedByUserId,
            Variables = variableRequests,
            Elements = elementRequests,
            Assets = assetRequests
        };

        await createLabelInputPort.Handle(createRequest);

        var response = new UpdateLabelResponse();
        outputPort.Handle(response);
    }
}
