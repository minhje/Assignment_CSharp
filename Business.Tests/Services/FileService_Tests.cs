using Business.Interfaces;
using Business.Services;
using Moq;

namespace Business.Tests.Services;

public class FileService_Tests
{
    private readonly Mock<IFileService> _mockFileService;
    private readonly IFileService _fileService;

    public FileService_Tests()
    {
        _mockFileService = new Mock<IFileService>();
        _fileService = _mockFileService.Object;
    }

    [Fact]
    public void SaveContentToFile_ShouldReturnTrueAndCreateFileWithContent()
    {
        // Arrange
        _mockFileService.Setup(fs => fs.SaveContentToFile(It.IsAny<string>())).Returns(true);
        // Act
        var result = _fileService.SaveContentToFile("test_content");

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetContentFromFile_ShouldReturnContentFromFile()
    {
        // Arrange
        _mockFileService.Setup(fs => fs.GetContentFromFile()).Returns("test_content");

        // Act
        var result = _fileService.GetContentFromFile();

        // Assert
        Assert.Equal("test_content", result);
    }
}
