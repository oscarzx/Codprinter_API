using Codprinter.Labels.Domain.Exceptions;

namespace Codprinter.Labels.Domain;

public class LabelEntity
{
    // Identity
    public Guid Id { get; private set; }

    // Template fields
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int Dpi { get; private set; }
    public string Units { get; private set; } // 'mm','in'
    public decimal WidthMm { get; private set; }
    public decimal HeightMm { get; private set; }
    public string RawJson { get; private set; }
    public string? ElementsJson { get; private set; }
    public bool IsActive { get; private set; }
    public Guid? CreatedByUserId { get; private set; }

    // Collections
    public IReadOnlyList<LabelVariable> Variables => _variables;
    public IReadOnlyList<LabelElement> Elements => _elements;
    public IReadOnlyList<AssetRef> Assets => _assets;

    private readonly List<LabelVariable> _variables = new();
    private readonly List<LabelElement> _elements = new();
    private readonly List<AssetRef> _assets = new();

    // Backward compatibility for existing mapping
    public string LabelName { get => Name; private set => Name = value; }

    // Private ctor
    private LabelEntity() { }

    public LabelEntity(Guid id, string labelName)
    {
        // Minimal validation for legacy path
        if (string.IsNullOrWhiteSpace(labelName))
            throw new InvalidLabelException("label.name.required", "Label name is required");

        Id = id;
        Name = labelName.Trim();
        IsActive = true;
        Dpi = 203; // sensible default
        Units = "mm";
        WidthMm = 0;
        HeightMm = 0;
        RawJson = string.Empty;
    }

    // Factory with full validation
    public static LabelEntity Create(
    Guid id,
    string name,
    string? description,
    int dpi,
    string units,
    decimal widthMm,
    decimal heightMm,
    string rawJson,
    string? elementsJson,
    bool isActive,
    Guid? createdByUserId,
    IEnumerable<LabelVariable>? variables,
    IEnumerable<LabelElement>? elements,
    IEnumerable<AssetRef>? assets)
    {
        // Template validations
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidLabelException("label.name.required", "Template name is required");
        var normName = name.Trim();
        if (normName.Length > 200)
            throw new InvalidLabelException("label.name.too_long", "Template name too long");

        if (dpi <= 0) throw new InvalidLabelException("label.dpi.invalid", "DPI must be >0");
        if (string.IsNullOrWhiteSpace(units)) throw new InvalidLabelException("label.units.required", "Units required");
        var allowedUnits = new[] { "mm", "in" };
        if (!allowedUnits.Contains(units)) throw new InvalidLabelException("label.units.invalid", "Units must be 'mm' or 'in'");

        if (widthMm <= 0) throw new InvalidLabelException("label.width.invalid", "Width must be >0");
        if (heightMm <= 0) throw new InvalidLabelException("label.height.invalid", "Height must be >0");

        if (string.IsNullOrWhiteSpace(rawJson)) throw new InvalidLabelException("label.rawjson.required", "RawJson is required");

        var entity = new LabelEntity
        {
            Id = id == Guid.Empty ? Guid.NewGuid() : id,
            Name = normName,
            Description = string.IsNullOrWhiteSpace(description) ? null : description,
            Dpi = dpi,
            Units = units,
            WidthMm = widthMm,
            HeightMm = heightMm,
            RawJson = rawJson,
            ElementsJson = string.IsNullOrWhiteSpace(elementsJson) ? null : elementsJson,
            IsActive = isActive,
            CreatedByUserId = createdByUserId,
        };

        // Variables validations
        if (variables != null)
        {
            var list = variables.ToList();
            // Unique names per template
            if (list.Select(v => v.Name).Where(n => !string.IsNullOrWhiteSpace(n)).GroupBy(n => n).Any(g => g.Count() > 1))
                throw new InvalidLabelException("variable.name.duplicate", "Variable names must be unique per template");

            foreach (var v in list)
            {
                v.Validate();
            }
            entity._variables.AddRange(list);
        }

        // Assets
        if (assets != null)
        {
            var assetList = assets.ToList();
            foreach (var a in assetList)
            {
                a.Validate();
            }
            entity._assets.AddRange(assetList);
        }

        // Elements validations
        if (elements != null)
        {
            var elList = elements.ToList();
            foreach (var e in elList)
            {
                e.Validate();
                // If element refers to variable by name, ensure it exists
                if (!string.IsNullOrWhiteSpace(e.LabelVariableName))
                {
                    if (!entity._variables.Any(v => v.Name == e.LabelVariableName))
                        throw new InvalidLabelException("element.variable.not_found", $"Element references unknown variable '{e.LabelVariableName}'");
                }
                // If element refers to an asset, ensure present in assets list
                if (e.AssetId.HasValue)
                {
                    if (!entity._assets.Any(a => a.AssetId == e.AssetId.Value))
                        throw new InvalidLabelException("element asset not_found", $"Element references unknown asset '{e.AssetId}'");
                }
            }
            entity._elements.AddRange(elList);
        }

        return entity;
    }
}

public class LabelVariable
{
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty; // 'string','number','date','bool','json'
    public string SourceType { get; set; } = string.Empty; // 'user','database','calculated','constant','api','realtime'
    public string? DefaultValue { get; set; }
    public bool IsRequired { get; set; }
    public string? ValidationRuleJson { get; set; }
    public string? CalculationExpr { get; set; }

    public DataBinding? DataBinding { get; set; }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name)) throw new InvalidLabelException("variable.name.required", "Variable name is required");
        if (string.IsNullOrWhiteSpace(DisplayName)) throw new InvalidLabelException("variable.display_name.required", "Variable display name is required");

        var allowedDataTypes = new[] { "string", "number", "date", "bool", "json" };
        if (!allowedDataTypes.Contains(DataType)) throw new InvalidLabelException("variable.data_type.invalid", "Invalid variable data type");

        var allowedSourceTypes = new[] { "user", "database", "calculated", "constant", "api", "realtime" };
        if (!allowedSourceTypes.Contains(SourceType)) throw new InvalidLabelException("variable.source_type.invalid", "Invalid variable source type");

        if (SourceType == "database" && DataBinding == null)
            throw new InvalidLabelException("variable.database.binding.required", "Database variables require a data binding");

        if (SourceType == "calculated" && string.IsNullOrWhiteSpace(CalculationExpr))
            throw new InvalidLabelException("variable.calculated.expr.required", "Calculated variables require a calculation expression");

        DataBinding?.Validate();
    }
}

public class DataBinding
{
    public string ConnectionName { get; set; } = string.Empty;
    public string QueryType { get; set; } = string.Empty; // 'table','view','sql'
    public string? TableName { get; set; }
    public string? ColumnName { get; set; }
    public string? SqlQuery { get; set; }
    public string? KeyMappingJson { get; set; }
    public int? CacheTtlSeconds { get; set; }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(ConnectionName)) throw new InvalidLabelException("binding.connection_name.required", "ConnectionName is required");
        var allowedQueryTypes = new[] { "table", "view", "sql" };
        if (!allowedQueryTypes.Contains(QueryType)) throw new InvalidLabelException("binding.query_type.invalid", "QueryType must be 'table','view' or 'sql'");

        if (QueryType is "table" or "view")
        {
            if (string.IsNullOrWhiteSpace(TableName)) throw new InvalidLabelException("binding.table.required", "TableName is required for table/view");
            if (string.IsNullOrWhiteSpace(ColumnName)) throw new InvalidLabelException("binding.column.required", "ColumnName is required for table/view");
        }
        else if (QueryType == "sql")
        {
            if (string.IsNullOrWhiteSpace(SqlQuery)) throw new InvalidLabelException("binding.sql_query.required", "SqlQuery is required for query_type='sql'");
        }

        if (CacheTtlSeconds is < 0)
            throw new InvalidLabelException("binding.cache_ttl.invalid", "Cache TTL must be >=0");
    }
}

public class LabelElement
{
    public string Type { get; set; } = string.Empty; // 'text','image','rect','barcode','qrcode'
    public decimal Xmm { get; set; }
    public decimal Ymm { get; set; }
    public decimal? WidthMm { get; set; }
    public decimal? HeightMm { get; set; }
    public decimal RotationDeg { get; set; }
    public int ZIndex { get; set; }
    public string PropsJson { get; set; } = string.Empty;

    public string? LabelVariableName { get; set; }
    public Guid? AssetId { get; set; }

    public void Validate()
    {
        var allowedTypes = new[] { "text", "image", "rect", "barcode", "qrcode" };
        if (!allowedTypes.Contains(Type)) throw new InvalidLabelException("element.type.invalid", "Invalid element type");
        if (Xmm < 0 || Ymm < 0) throw new InvalidLabelException("element.position.invalid", "Element position must be >=0");
        if (RotationDeg is < -360 or > 360) throw new InvalidLabelException("element.rotation.invalid", "Rotation must be between -360 and360");
        if (ZIndex < 0) throw new InvalidLabelException("element.zindex.invalid", "ZIndex must be >=0");
        if (string.IsNullOrWhiteSpace(PropsJson)) throw new InvalidLabelException("element.props.required", "PropsJson is required");

        // dimensional checks when provided
        if (WidthMm is <= 0) WidthMm = null;
        if (HeightMm is <= 0) HeightMm = null;

        if (Type == "image" && !AssetId.HasValue)
            throw new InvalidLabelException("element.image.asset.required", "Image element requires an AssetId");
        if ((Type == "text" || Type == "barcode" || Type == "qrcode") && string.IsNullOrWhiteSpace(LabelVariableName))
            throw new InvalidLabelException("element.variable.required", "Text/Barcode/QRCode elements must reference a variable");
    }
}

public class AssetRef
{
    public Guid AssetId { get; set; }
    public string Type { get; set; } = string.Empty; // 'image','font'
    public string Name { get; set; } = string.Empty;
    public string MimeType { get; set; } = string.Empty;
    public string? StorageUrl { get; set; }
    public byte[]? BinaryData { get; set; }
    public string? Checksum { get; set; }
    public Guid? CreatedByUserId { get; set; }

    public void Validate()
    {
        if (AssetId == Guid.Empty) AssetId = Guid.NewGuid();
        var allowedTypes = new[] { "image", "font" };
        if (!allowedTypes.Contains(Type)) throw new InvalidLabelException("asset.type.invalid", "Invalid asset type");
        if (string.IsNullOrWhiteSpace(Name)) throw new InvalidLabelException("asset.name.required", "Asset name is required");
        if (string.IsNullOrWhiteSpace(MimeType)) throw new InvalidLabelException("asset.mimetype.required", "Asset mime type is required");
        if (BinaryData == null || BinaryData.Length == 0) throw new InvalidLabelException("asset.binary.required", "Asset binary data is required");
    }
}
