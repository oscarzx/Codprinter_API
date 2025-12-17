namespace Codprinter.Labels.Application.Dtos.CreateLabel;

public class CreateLabelRequest
{
    // Backward compatibility with existing interactor expecting LabelName
    public string LabelName { get => Name; set => Name = value; }

    // Template fields (label_templates)
    public string Name { get; set; }
    public string? Description { get; set; }
    public int Dpi { get; set; }
    public string Units { get; set; } // 'mm', 'in'
    public decimal WidthMm { get; set; }
    public decimal HeightMm { get; set; }
    public string RawJson { get; set; } // faithful editor state
    public string? ElementsJson { get; set; } // optional normalized snapshot
    public bool IsActive { get; set; } = true;
    public Guid? CreatedByUserId { get; set; }

    // Variables (label_variables)
    public List<LabelVariableRequest> Variables { get; set; } = new();

    // Elements (label_elements) - optional normalization
    public List<LabelElementRequest> Elements { get; set; } = new();

    // Assets to create/use (assets) - optional; referenced by elements
    public List<AssetRequest> Assets { get; set; } = new();
}

public class LabelVariableRequest
{
    public string Name { get; set; }
    public string DisplayName { get; set; }
    public string DataType { get; set; } // 'string','number','date','bool','json'
    public string SourceType { get; set; } // 'user','database','calculated','constant','api','realtime'
    public string? DefaultValue { get; set; }
    public bool IsRequired { get; set; }
    public string? ValidationRuleJson { get; set; }
    public string? CalculationExpr { get; set; }

    // Optional: database binding when source_type == 'database'
    public DataBindingRequest? DataBinding { get; set; }
}

public class DataBindingRequest
{
    public string ConnectionName { get; set; }
    public string QueryType { get; set; } // 'table','view','sql'
    public string? TableName { get; set; }
    public string? ColumnName { get; set; }
    public string? SqlQuery { get; set; } // parametrized query
    public string? KeyMappingJson { get; set; } // mapping from context
    public int? CacheTtlSeconds { get; set; }
}

public class LabelElementRequest
{
    public string Type { get; set; } // 'text','image','rect','barcode','qrcode'
    public decimal Xmm { get; set; }
    public decimal Ymm { get; set; }
    public decimal? WidthMm { get; set; }
    public decimal? HeightMm { get; set; }
    public decimal RotationDeg { get; set; } = 0;
    public int ZIndex { get; set; }
    public string PropsJson { get; set; }

    // Optional references
    public string? LabelVariableName { get; set; } // link to variable by name
    public Guid? AssetId { get; set; } // link to existing asset
}

public class AssetRequest
{
    public string Type { get; set; } // 'image','font'
    public string Name { get; set; }
    public string MimeType { get; set; }
    public string? StorageUrl { get; set; }
    public byte[] BinaryData { get; set; }
    public string? Checksum { get; set; } // SHA-256 recommended
    public Guid? CreatedByUserId { get; set; }
}
