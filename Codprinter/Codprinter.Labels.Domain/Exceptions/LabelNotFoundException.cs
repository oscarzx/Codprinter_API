namespace Codprinter.Labels.Domain.Exceptions
{
    public sealed class LabelNotFoundException : DomainException
    {
        public LabelNotFoundException(string code, string message)
        : base(code, message)
        {
        }

        public static LabelNotFoundException ByName(string templateName) =>
        new LabelNotFoundException(
        "label.not_found",
        $"Label template '{templateName}' was not found.");

        public static LabelNotFoundException ById(Guid id) =>
        new LabelNotFoundException(
        "label.not_found",
        $"Label template with id '{id}' was not found.");
    }
}
