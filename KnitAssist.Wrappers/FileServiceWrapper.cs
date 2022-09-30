using IronPdf;
namespace KnitAssist.Wrappers;
public class FileServiceWrapper : IFileServiceWrapper
{
    public string GetTextFromPdf(string filePath)
    {
        var pdf = PdfDocument.FromFile(filePath);
        
        return pdf.ExtractAllText();
    }
}