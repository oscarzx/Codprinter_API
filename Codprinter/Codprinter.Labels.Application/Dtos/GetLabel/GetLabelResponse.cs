namespace Codprinter.Labels.Application.Dtos.GetLabel;

public class GetLabelResponse
{
    // Template
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Dpi { get; set; }
    public string Units { get; set; } = string.Empty;
    public decimal WidthMm { get; set; }
    public decimal HeightMm { get; set; }
    public string RawJson { get; set; } = string.Empty;
    public string? ElementsJson { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedByUserId { get; set; }

    // Collections
    public List<GetLabelVariableDto> Variables { get; set; } = new();
    public List<GetLabelElementDto> Elements { get; set; } = new();
    public List<GetAssetDto> Assets { get; set; } = new();
}

public class GetLabelVariableDto
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
    public GetDataBindingDto? DataBinding { get; set; }
}

public class GetDataBindingDto
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

public class GetLabelElementDto
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

    public Guid? LabelVariableId { get; set; }
    public Guid? AssetId { get; set; }
}

public class GetAssetDto
{
    public Guid Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string MimeType { get; set; } = string.Empty;
    public string? StorageUrl { get; set; }
    public byte[] BinaryData { get; set; } = Array.Empty<byte>();
    public string? Checksum { get; set; }
}
