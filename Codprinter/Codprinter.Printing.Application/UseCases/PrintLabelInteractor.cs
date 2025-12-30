using Codprinter.Printing.Application.Dtos;
using Codprinter.Printing.Application.Exceptions;
using Codprinter.Printing.Application.Interfaces;
using Codprinter.Printing.Domain.Entities;
using System.Net.Sockets;
using System.Text;

namespace Codprinter.Printing.Application.UseCases;

internal class PrintLabelInteractor(
    IPrintLabelOutputPort outputPort) : IPrintLabelInputPort
{
    public async Task Handle(PrintLabelRequest request)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        if (outputPort is null) throw new ArgumentNullException(nameof(outputPort));

        var entity = new PrintLabelEntity(request.ZplCommand, request.PrinterIp, request.PrinterPort);
        try
        {
            using var client = new TcpClient();

            // ConnectAsync does not accept CancellationToken in net8's TcpClient API.
            await client.ConnectAsync(entity.PrinterIp, entity.PrinterPort);

            await using var networkStream = client.GetStream();

            // Zebra printers typically expect ASCII/UTF-8; UTF-8 is safe for standard ZPL.
            var payload = Encoding.UTF8.GetBytes(entity.ZplCommand);
            await networkStream.WriteAsync(payload);
            await networkStream.FlushAsync();

            await outputPort.Handle(new PrintLabelResponse
            {
                Message = "Print job sent successfully."
            });
        }
        catch (Exception ex) when (ex is SocketException or IOException or ObjectDisposedException)
        {
            throw new PrintingApplicationException("Unable to send ZPL to the printer via TCP/IP.", ex);
        }
    }
}
