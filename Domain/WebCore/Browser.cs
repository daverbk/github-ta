using System.Collections.Concurrent;
using Domain.Configuration;
using OpenQA.Selenium;
using Xunit.Sdk;

namespace Domain.WebCore;

public class Browser
{
    private static readonly ConcurrentDictionary<string, IWebDriver> DriverCollection = new();

    public static IWebDriver Driver
    {
        get
        {
            DriverCollection.TryGetValue(AsyncTestSyncContext.Current.ToString(), out var driver);
                
            return driver!;
        }

        private set => DriverCollection.TryAdd(AsyncTestSyncContext.Current.ToString(), value);
    }
        
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
        Driver?.Quit();
        Driver?.Dispose();
        DriverCollection.TryRemove(AsyncTestSyncContext.Current.ToString(), out _);
    }
}
