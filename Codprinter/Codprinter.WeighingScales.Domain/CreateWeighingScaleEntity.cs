using Codprinter.WeighingScales.Domain.Exceptions;

namespace Codprinter.WeighingScales.Domain
{
    public class CreateWeighingScaleEntity
    {
        public string Name { get; }
        public string IP { get; }
        public int Port { get; }
        public Guid UserId { get; set; }

        public CreateWeighingScaleEntity(string name, string ip, int port, Guid userId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new InvalidWeighingScaleException("weighingscale.name.required", "El nombre es requerido.");

            if (string.IsNullOrWhiteSpace(ip))
                throw new InvalidWeighingScaleException("weighingscale.ip.required", "La IP es requerida.");

            var normalizedIp = ip.Trim();
            if (!System.Net.IPAddress.TryParse(normalizedIp, out _))
                throw new InvalidWeighingScaleException("weighingscale.ip.invalid", "La IP no es válida.");

            if (port <= 0 || port > 65535)
                throw new InvalidWeighingScaleException("weighingscale.port.invalid", "El puerto debe estar entre 1 y 65535.");

            Name = name.Trim().ToUpper();
            IP = normalizedIp;
            Port = port;
            UserId = userId;
        }
    }
}
