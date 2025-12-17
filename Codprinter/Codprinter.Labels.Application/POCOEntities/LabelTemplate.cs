namespace Codprinter.Labels.Application.POCOEntities;

public class LabelTemplate
{
    public Guid Id { get; set; }
    public string TemplateName { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int Dpi { get; set; }
    public string Units { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public string RawJson { get; set; }
    public string? ElementsJson { get; set; }
    public bool IsActive { get; set; }
    public Guid? CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }


}
/*label_templates

label_template_id: identificador único de la plantilla.
name: nombre único de la plantilla; usado para abrir por nombre e imprimir sin abrir el diseñador (ej. prueba_100_50).
description: texto descriptivo opcional.
dpi: resolución del lienzo; usada para conversión mm→px al render.
units: unidades base del diseño; normalmente mm.
width_mm/height_mm: dimensiones de la etiqueta; validan contra capacidades de impresora.
raw_json: estado fiel del editor (React-Konva) para reconstrucción exacta; el backend lo devuelve al frontend para abrir/editar.
elements_json: snapshot normalizado para render/impresión rápida; opcional si solo usas raw_json.
is_active: habilita/deshabilita plantilla sin borrarla.
created_by_user_id: autor (FK opcional).
created_at/updated_at: timestamps de creación/última actualización.*/