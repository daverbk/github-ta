using Domain.WebCore;

namespace Tests;

public class DriverFixture : IDisposable
{
    public DriverFixture()
    {
        Browser.InitBrowser();
    }
    
    public void Dispose() => Browser.QuitDriver();
}
