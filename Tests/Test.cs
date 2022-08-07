using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class Test : IClassFixture<DriverFixture>
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

public class Test1 : IClassFixture<DriverFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Test1(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test2()
    {
        _testOutputHelper.WriteLine("sss");
    }
}

public class Test2 : IClassFixture<DriverFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Test2(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        _testOutputHelper.WriteLine("sss");
    }
}

public class Test3 : IClassFixture<DriverFixture>
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Test3(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Test1()
    {
        _testOutputHelper.WriteLine("sss");
    }
}
