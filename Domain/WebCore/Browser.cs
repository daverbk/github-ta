using OpenQA.Selenium;

namespace Domain.WebCore;

public class Browser
{
    [field: ThreadStatic]
    public static IWebDriver Driver { get; private set; }

    public static void InitBrowser()
    {
        Driver = Configurator.BrowserType switch
        {
            "chrome" => DriverFactory.GetChromeDriver(),
            "firefox" => DriverFactory.GetFirefoxDriver(),
            _ => throw new ArgumentException("Check that your BrowserType property in appsettings.json is set to either chrome or firefox.")
        };

        Driver.Manage().Window.Maximize();
        Driver.Manage().Cookies.DeleteAllCookies();
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
    
    public static void QuitDriver()
    {
        Driver.Quit();
    }
}
