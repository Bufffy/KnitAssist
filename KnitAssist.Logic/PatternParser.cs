namespace KnitAssist.Logic;

public class PatternParser : IPatternParser
{
    private IFileServiceWrapper _fileService;

    public PatternParser(IFileServiceWrapper fileService)
    {
        _fileService = fileService;
    }

    public string GetText(string filePath)
    {
        string text;
        try
        {
            text = _fileService.GetTextFromPdf(filePath);
        }
        catch (Exception e)
        {
            throw new FileNotFoundException(e.Message);
        }

        return text;
    }
}
