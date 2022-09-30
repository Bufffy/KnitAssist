namespace KnitAssist.Tests;

public class PatternParserTests
{
    private readonly PatternParser _parser;
    private readonly Mock<IFileService> _mockFileService;

    public PatternParserTests()
    {
        _mockFileService = new Mock<IFileService>();
        _parser = new PatternParser(_mockFileService.Object);
    }

    [Fact]
    public void GetText_ThrowsFileNotFoundException_WhenGetPdfFails()
    {
        _mockFileService.Setup(x => x.GetPdf(It.IsAny<String>())).Throws<FileNotFoundException>();

        Assert.Throws<FileNotFoundException>(() => _parser.GetText("pattern.pdf"));
    }

    [Fact]
    public void GetText_GetsPdfFile()
    {
        var fileName = "pattern.pdf";

        _parser.GetText(fileName);

        _mockFileService.Verify(x => x.GetPdf(fileName));
    }
}