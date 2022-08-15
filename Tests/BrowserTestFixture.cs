using Domain.WebCore;

namespace Tests;

public class BrowserTestFixture : IDisposable
{
    public BrowserTestFixture()
    {
        Browser.InitBrowser();
    }

    public void Dispose() => Browser.QuitDriver();
}
