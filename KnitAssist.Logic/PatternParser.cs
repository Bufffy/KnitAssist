using IronPdf;

namespace KnitAssist.Logic;

public class PatternParser : IPatternParser
{
    private IFileService _fileService;

    public PatternParser(IFileService fileService)
    {
        _fileService = fileService;
    }

    public void GetText(string filePath)
    {
        var pdf = GetPdf(filePath);
    }

    private PdfDocument GetPdf(string filePath)
    {
        PdfDocument pdf;
        try
        {
            pdf = _fileService.GetPdf(filePath);
        }
        catch (Exception e)
        {
            throw new FileNotFoundException(e.Message);
        }

        return pdf;
    }
}
