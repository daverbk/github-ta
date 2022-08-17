using Domain.WebCore;

namespace Tests.E2E;

public class BrowserTestFixture : IDisposable
{
    public BrowserTestFixture()
    {
        Browser.InitBrowser();
    }

    public void Dispose() => Browser.QuitDriver();
}
