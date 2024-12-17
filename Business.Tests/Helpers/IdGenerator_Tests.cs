using Business.Helpers;

namespace Business.Tests.Helpers;

public class IdGenerator_Tests
{
    [Fact]
    public void GenerateUniqueId_ShouldReturnGuidAsString()
    {
        var result = IdGenerator.GenerateUniqueId();

        Assert.True(Guid.TryParse(result, out _));
    }
}
