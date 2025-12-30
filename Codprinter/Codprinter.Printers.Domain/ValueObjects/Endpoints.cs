namespace Codprinter.Printers.Domain.ValueObjects
{
    public class Endpoints
    {
        public const string CreatePrinter = $"/{nameof(CreatePrinter)}";
        public const string GetPrinterById = $"/{nameof(GetPrinterById)}";
        public const string GetPrinterByName = $"/{nameof(GetPrinterByName)}";
        public const string GetPrinterByIp = $"/{nameof(GetPrinterByIp)}";
        public const string GetAllPrinters = $"/{nameof(GetAllPrinters)}";
        public const string UpdatePrinter = $"/{nameof(UpdatePrinter)}";
    }
}
