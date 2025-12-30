namespace Codprinter.Printers.Application.Exceptions;

public sealed class PrinterIpConflictException : Exception
{
    public PrinterIpConflictException(string message) : base(message) { }
}
