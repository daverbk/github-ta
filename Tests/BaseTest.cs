using Domain.WebCore;
using Xunit;
using Xunit.Abstractions;

namespace Tests;

public class BaseTest : IDisposable
{
    [Fact]
    protected void InitializeTests()
    {
        Browser.InitBrowser();
    }
    
    public void Dispose()
    {
        Browser.QuitDriver();
    }
}
