namespace Codprinter.Labels.Application.POCOEntities;

public class Assets
{
    public Guid Id { get; set; }
    public string Type { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string MimeType { get; set; } = null!;
    public string? StorageUrl { get; set; }
    public byte[] BinaryData { get; set; } = null!;
    public string Checksum { get; set; } = null!;
    public Guid? CreatedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
}

/*assets

asset_id: ID del recurso (imagen/fuente).
type: tipo de recurso (image, font).
name: nombre lógico para búsqueda/reuso.
mime_type: tipo MIME del binario (image/png, image/jpeg, etc.).
storage_url: URL si se almacena externamente (no requerido en tu caso).
binary_data: binario del recurso; el backend lo sirve al render para colocar la imagen.
checksum: hash del binario (SHA-256) usado para deduplicación y ETag; índice único condicional.
created_by_user_id: usuario que subió el recurso (FK opcional).
created_at: timestamp de alta.*/