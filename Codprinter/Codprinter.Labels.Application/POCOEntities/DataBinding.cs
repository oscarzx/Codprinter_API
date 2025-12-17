namespace Codprinter.Labels.Application.POCOEntities;

public class DataBinding
{
    public Guid Id { get; set; }
    public Guid LabelVariableId { get; set; }
    public string ConnectionName { get; set; } = null!;
    public string QueryType { get; set; } = null!;
    public string? TableName { get; set; }
    public string? ColumnName { get; set; }
    public string? SqlQuery { get; set; }
    public string KeyMappingJson { get; set; } = null!;
    public int? CacheTtlSeconds { get; set; }
}

/*data_bindings

data_binding_id: ID de binding.
label_variable_id: variable a la que se aplica el binding (debe tener source_type='database').
connection_name: alias de conexión definido en configuración del backend; permite multi-origen sin exponer connection strings aquí.
query_type: tipo de acceso (table, view, sql).
table_name/column_name: usados cuando query_type es table/view.
sql_query: consulta parametrizada cuando query_type='sql'; el backend inyecta parámetros desde key_mapping_json.
key_mapping_json: mapeo de claves del contexto de impresión a parámetros de la consulta (ej. { "producto_id": "{context.productoId}" }).
cache_ttl_seconds: tiempo de vida de cache en segundos para optimizar lecturas repetidas.*/