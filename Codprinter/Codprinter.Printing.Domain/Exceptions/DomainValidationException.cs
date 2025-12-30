using System.Runtime.Serialization;

namespace Codprinter.Printing.Domain.Exceptions;

[Serializable]
public sealed class DomainValidationException : Exception
{
 public DomainValidationException(string message) : base(message) { }

 private DomainValidationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
