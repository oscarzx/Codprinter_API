namespace Codprinter.Printers.Application.Exceptions;

public sealed class PrinterNotFoundException : Exception
{
    public PrinterNotFoundException(string message) : base(message) { }
}
