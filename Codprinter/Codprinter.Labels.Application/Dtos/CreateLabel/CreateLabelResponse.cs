namespace Codprinter.Labels.Application.Dtos.CreateLabel;

public class CreateLabelResponse
{
    public Guid LabelId { get; set; }
    public string Message { get; set; } = "Etiqueta creada correctamente";
}
