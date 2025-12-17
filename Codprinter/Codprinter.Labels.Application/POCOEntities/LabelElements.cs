namespace Codprinter.Labels.Application.POCOEntities;

public class LabelElements
{
    public Guid Id { get; set; }
    public Guid LabelTemplateId { get; set; }
    public string Type { get; set; } = null!;
    public float Xmm { get; set; }
    public float Ymm { get; set; }
    public float? WidthMm { get; set; }
    public float? HeightMm { get; set; }
    public float RotationDeg { get; set; }
    public int ZIndex { get; set; }
    public string PropsJson { get; set; } = null!;
    public Guid? LabelVariableId { get; set; }
    public Guid? AssetId { get; set; }
}
/*label_elements (opcional)

label_element_id: ID del elemento del diseño.
label_template_id: FK a la plantilla (sin versiones).
type: tipo de elemento (text, image, rect, barcode, qrcode).
xmm/ymm: posición en mm.
width_mm/height_mm: dimensiones en mm (algunos tipos pueden no requerir).
rotation_deg: rotación en grados.
z_index: orden de apilamiento para render.
props_json: propiedades específicas del elemento (fuente, tamaño, alineación, formato de código de barras/QR, color, etc.).
label_variable_id: si el contenido proviene de una variable (ej. valor de texto o de código de barras).
asset_id: si un elemento de tipo imagen hace referencia a un asset.*/