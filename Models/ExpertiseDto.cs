namespace CadLibBackend.Models;
public class ExpertiseDto
{
    public string? Status { get; set; }
    public DateTime? Date { get; set; }
    public string Message { get; set; } = null!;
    public string? Comment { get; set; }
    public int? IdObject { get; set; }
    public int? IdFile { get; set; }
    public int IdNode { get; set; }
    public string? ImageBase64 { get; set; }
    public string? DocumentBase64 { get; set; } // Документ в формате Base64
    public string? DocumentFileName { get; set; } // Имя файла документа
    public string? HazardCategory { get; set; } // Новое поле
}