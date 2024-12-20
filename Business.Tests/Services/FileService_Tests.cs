using Business.Interfaces;
using Business.Services;
using Moq;

namespace Business.Tests.Services;

public class FileService_Tests
{
    private readonly Mock<IFileService>();
    private readonly IFileService _fileService;

    public FileService_Tests()
    {
        _fileService = new FileService("TestData", "tests_contacts.json");
    }

    [Fact]
    public void SaveContentToFile_ShouldReturnTrueAndCreateFileWithContent()
    {
        // Act
        var result = _fileService.SaveContentToFile("test_content");

        // Assert
        Assert.True(result);
    }
}
