using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class Test : BaseTest

{
    private readonly ITestOutputHelper _testOutputHelper;

    public Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        _testOutputHelper.WriteLine("sss");
    }
}
