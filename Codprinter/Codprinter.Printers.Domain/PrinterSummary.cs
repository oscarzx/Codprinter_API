namespace Codprinter.Printers.Domain;

/// <summary>
/// Proyección de dominio para listados (evita exponer detalles de persistencia).
/// </summary>
public sealed record PrinterSummary(
 Guid Id,
 string PrinterIp,
 int PrinterPort,
 string PrinterName,
 DateTime CreatedAt,
 Guid CreatedBy);
