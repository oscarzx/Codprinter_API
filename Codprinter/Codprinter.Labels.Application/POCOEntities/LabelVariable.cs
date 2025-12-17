namespace Codprinter.Labels.Application.POCOEntities;

public class LabelVariable
{
    public Guid Id { get; set; }
    public Guid LabelTemplateId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string DataType { get; set; } = string.Empty;
    public string SourceType { get; set; } = string.Empty;
    public string? DefaultValue { get; set; }
    public bool IsRequired { get; set; }
    public string? ValidationRuleJson { get; set; }
    public string? CalculationExpr { get; set; }
    public DateTime CreatedAt { get; set; }
}

/*label_variables

label_variable_id: ID de variable.
label_template_id: FK a plantilla que la usa.
name: clave única, usada por el motor de render para sustituir contenidos (ej. producto_nombre, peso_bascula).
display_name: etiqueta amigable para formularios/UX.
data_type: tipo de dato validado (string, number, date, bool, json).
source_type: fuente del valor (user para captura, database desde BD, calculated por reglas, constant fijo, api/realtime para datos en tiempo real).
default_value: valor por defecto si no se provee en la solicitud.
is_required: indica si es obligatorio para poder imprimir.
validation_rule_json: reglas de validación (regex, rangos, máscaras); el backend valida contra esto al recibir datos.
calculation_expr: expresión/regla que el backend usa para calcular el valor cuando source_type='calculated'.
created_at: timestamp de alta.

 created_at TIMESTAMPTZ NOT NULL DEFAULT NOW(),
  CONSTRAINT uq_label_variables UNIQUE (label_template_id, name)
*/