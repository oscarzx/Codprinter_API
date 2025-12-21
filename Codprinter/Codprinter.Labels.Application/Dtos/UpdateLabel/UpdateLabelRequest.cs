using Codprinter.Labels.Application.Dtos.CreateLabel;

namespace Codprinter.Labels.Application.Dtos.UpdateLabel;

/// <summary>
/// Request DTO to update an existing label template. Extends CreateLabelRequest by
/// adding Ids so updates can be done by identity.
/// </summary>
public class UpdateLabelRequest : CreateLabelRequest
{
    public Guid Id { get; set; }

    public new List<UpdateLabelVariableDto> Variables { get; set; } = new();
    public new List<UpdateLabelElementDto> Elements { get; set; } = new();
    public new List<UpdateAssetDto> Assets { get; set; } = new();
}

public class UpdateLabelVariableDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public string SourceType { get; set; } = string.Empty;
    public string? DefaultValue { get; set; }
    public bool IsRequired { get; set; }
    public string? ValidationRuleJson { get; set; }
    public string? CalculationExpr { get; set; }
    public UpdateDataBindingDto? DataBinding { get; set; }
}

public class UpdateDataBindingDto
{
    public Guid Id { get; set; }
    public string ConnectionName { get; set; } = string.Empty;
    public string QueryType { get; set; } = string.Empty;
    public string? TableName { get; set; }
    public string? ColumnName { get; set; }
    public string? SqlQuery { get; set; }
    public string? KeyMappingJson { get; set; }
    public int? CacheTtlSeconds { get; set; }
}

public class UpdateLabelElementDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Xmm { get; set; }
    public decimal Ymm { get; set; }
    public decimal? WidthMm { get; set; }
    public decimal? HeightMm { get; set; }
    public decimal RotationDeg { get; set; }
    public int ZIndex { get; set; }
    public string PropsJson { get; set; } = string.Empty;
    public string? LabelVariableName { get; set; }
    public Guid? AssetId { get; set; }
}

public class UpdateAssetDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MimeType { get; set; } = string.Empty;
    public string? StorageUrl { get; set; }
    public byte[] BinaryData { get; set; } = Array.Empty<byte>();
    public string? Checksum { get; set; }
    public Guid? CreatedByUserId { get; set; }
}
