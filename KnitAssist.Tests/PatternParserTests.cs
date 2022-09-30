namespace KnitAssist.Tests;

public class PatternParserTests
{
    private readonly PatternParser _parser;
    private readonly Mock<IFileServiceWrapper> _mockFileService;

    public PatternParserTests()
    {
        _mockFileService = new Mock<IFileServiceWrapper>();
        _parser = new PatternParser(_mockFileService.Object);
    }

    [Fact]
    public void GetText_GetsAllText_FromPdf()
    {
        var filePath = "pattern.pdf";
        _mockFileService.Setup(x => x.GetTextFromPdf(filePath));

        _parser.GetText(filePath);

        _mockFileService.Verify(x => x.GetTextFromPdf(filePath), Times.Once);
    }

    [Fact]
    public void GetText_ThrowsFileNotFoundException_WhenGetAllTextFromPdfFails()
    {
        _mockFileService.Setup(x => x.GetTextFromPdf(It.IsAny<String>())).Throws<FileNotFoundException>();

        Assert.Throws<FileNotFoundException>(() => _parser.GetText("pattern.pdf"));
    }

    [Fact]
    public void GetText_ReturnsAllText_FromPdf()
    {
        var filePath = "pattern.pdf";
        var text = "pattern instructions";
        _mockFileService.Setup(x => x.GetTextFromPdf(filePath)).Returns(text);

        var output = _parser.GetText(filePath);

        Assert.Equal(text, output);
    }
}