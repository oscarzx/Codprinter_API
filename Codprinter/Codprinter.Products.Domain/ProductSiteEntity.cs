namespace Codprinter.Products.Domain;

/// <summary>
/// Asociación entre producto y sede/sitio.
/// Un mismo <see cref="ProductCode"/> se repite por múltiples sedes.
/// </summary>
public class ProductSiteEntity
{
    public Guid Id { get; set; }

    /// <summary>
    /// Nombre de la sede/sitio (ej: "SUPERMERCADO GIRARDOTA").
    /// </summary>
    public string Site { get; set; }

    /// <summary>
    /// Código de barras (puede venir como "#N/D").
    /// </summary>
    public string? Barcode { get; set; }

    /// <summary>
    /// Tipo de precio (ej: "Fijo", "Variable").
    /// </summary>
    public string? PriceType { get; set; }

    /// <summary>
    /// Indicador de liquidación/clearance.
    /// </summary>
    public string? Clearance { get; set; }

    /// <summary>
    /// Código del producto con el que se relaciona el registro.
    /// </summary>
    public string ProductCode { get; set; }

    public string? LegacyProductCode { get; set; }

    /// <summary>
    /// Nombre del producto en la sede (puede variar por sede).
    /// </summary>
    public string? ProductName { get; set; }

    public decimal Price { get; set; }

    /// <summary>
    /// Navegación opcional hacia el producto.
    /// </summary>
    public ProductEntity? Product { get; set; }

    public ProductSiteEntity(
    Guid id,
    string site,
    string productCode,
    decimal price,
    string? barcode = null,
    string? priceType = null,
    string? clearance = null,
    string? legacyProductCode = null,
    string? productName = null)
    {
        Id = id;
        Site = site;
        ProductCode = productCode;
        Price = price;
        Barcode = barcode;
        PriceType = priceType;
        Clearance = clearance;
        LegacyProductCode = legacyProductCode;
        ProductName = productName;
    }

    // Constructor para EF
    public ProductSiteEntity() { }
}
