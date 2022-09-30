namespace KnitAssist.Interfaces;
using IronPdf;

public interface IFileService
{
    PdfDocument GetPdf(string fileName);
}