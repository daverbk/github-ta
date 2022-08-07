using System.Collections.Concurrent;
using Domain.Configuration;
using OpenQA.Selenium;
using Xunit.Sdk;

namespace Domain.WebCore;

public class Browser
{
    [field: ThreadStatic]
    public static ThreadLocal<IWebDriver> Driver { get; private set; } = null!;

    public static void InitBrowser()
    {
        Driver = Configurator.BrowserType switch
        {
            "chrome" => DriverFactory.GetChromeDriver(),
            "firefox" => DriverFactory.GetFirefoxDriver(),
            _ => throw new ArgumentException("Check that your BrowserType property in appsettings.json is set to either chrome or firefox.")
        };

        Driver.Value!.Manage().Window.Maximize();
        Driver.Value!.Manage().Cookies.DeleteAllCookies();
        Driver.Value!.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
    }
    
    public static void QuitDriver()
    {
        Driver.Value!.Quit();
    }
}
