using System.Net;
using Codprinter.Printing.Domain.Entities;
using Codprinter.Printing.Domain.Exceptions;

namespace Codprinter.Printing.Domain.Services;

public sealed class PrintLabelDomainService
{
 public PrintLabelEntity ValidateAndCreate(string zplCommand, string printerIp, int printerPort)
 {
 if (string.IsNullOrWhiteSpace(zplCommand))
 throw new DomainValidationException("ZPL command is required.");

 // A reasonable guardrail to prevent accidental huge payloads in domain.
 // ZPL can be large, but this ensures we don't accept unbounded input.
 const int maxZplLength =200_000;
 if (zplCommand.Length > maxZplLength)
 throw new DomainValidationException($"ZPL command exceeds maximum length ({maxZplLength}).");

 if (!zplCommand.Contains("^XA", StringComparison.OrdinalIgnoreCase) ||
 !zplCommand.Contains("^XZ", StringComparison.OrdinalIgnoreCase))
 {
 throw new DomainValidationException("ZPL command must include ^XA (start) and ^XZ (end)." );
 }

 if (string.IsNullOrWhiteSpace(printerIp))
 throw new DomainValidationException("Printer IP is required.");

 if (!IPAddress.TryParse(printerIp, out var ipAddress) || ipAddress.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
 throw new DomainValidationException("Printer IP must be a valid IPv4 address.");

 if (printerPort is <1 or >65535)
 throw new DomainValidationException("Printer port must be between1 and65535.");

 return new PrintLabelEntity(zplCommand.Trim(), printerIp.Trim(), printerPort);
 }
}
